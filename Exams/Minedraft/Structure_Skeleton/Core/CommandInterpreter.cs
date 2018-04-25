using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }
    public string ProcessCommand(IList<string> args)
    {
        ICommand commandInstance = CreateCommand(args);

        try
        {
            string result = commandInstance.Execute();

            return result;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string command = args[0].Trim();

        string fullCommand = command + "Command";

        Type cmdToExecute = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == fullCommand);

        if (cmdToExecute == null)
        {
            throw new InvalidOperationException("Command Not Found");
        }

        var isAssignable = typeof(ICommand).IsAssignableFrom(cmdToExecute);

        if (!isAssignable)
        {
            throw new ArgumentException("This is not a command!");
        }

        List<string> data = new List<string>(args.Skip(1).ToList());

        ConstructorInfo constructorInfo = cmdToExecute.GetConstructors().First();

        ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameterInfos.Length; i++)
        {
            Type paramType = parameterInfos[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType()
                    .GetProperties().FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand commandInstance = (ICommand) Activator.CreateInstance(cmdToExecute, parameters);
        return commandInstance;
    }
}