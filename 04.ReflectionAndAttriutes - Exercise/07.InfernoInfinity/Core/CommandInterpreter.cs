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

    public ICommand InterpretCommand(string[] data, string command)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        command = command + "Command";
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == command);

        if (commandType == null)
        {
            throw new ArgumentException("Invalid Command!");
        }

        var isAssignable = typeof(ICommand).IsAssignableFrom(commandType);

        if (!isAssignable)
        {
            throw new ArgumentException($"{command} is not a Command!");
        }

        FieldInfo[] fieldsToInject = commandType
                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                            .ToArray();

        object[] injectObjects = fieldsToInject
            .Select(ft => this.serviceProvider.GetService(ft.FieldType))
            .ToArray();

        object[] constructorObjects = new object[] { data }.Concat(injectObjects)
            .ToArray();

        return (ICommand)Activator.CreateInstance(commandType, constructorObjects);
    }
}