using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        Assembly assembly = Assembly.GetCallingAssembly();

        string fullCommandName = commandName + "command";
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == fullCommandName);

        if (commandType == null)
        {
            throw new ArgumentException($"Invalid Command!");
        }

        bool isAssignable = typeof(IExecutable).IsAssignableFrom((Type)commandType);

        if (!isAssignable)
        {
            throw new ArgumentException($"{commandName} is NOT a Command!");
        }

        FieldInfo[] fieldsToInject = commandType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
            .ToArray();

        object[] injectObjects = fieldsToInject
            .Select(ft => this.serviceProvider.GetService(ft.FieldType))
            .ToArray();

        object[] constructortObjects = new object[] { data }
            .Concat(injectObjects)
            .ToArray();

        IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constructortObjects);

        return instance;
    }
}