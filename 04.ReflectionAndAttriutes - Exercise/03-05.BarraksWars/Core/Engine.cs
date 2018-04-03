using System;
using System.Linq;
using System.Reflection;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                string[] data = input.Split();
                string commandName = data[0];

                IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                MethodInfo method = typeof(IExecutable).GetMethods().First();

                string result = method.Invoke(command, null).ToString();

                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}