using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while (input != "END")
        {
            var data = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            string command = data[0];

            var instance = this.commandInterpreter.InterpretCommand(data, command);

            var method = typeof(ICommand).GetMethods().First();

            method.Invoke(instance, null);

            input = Console.ReadLine();
        }
    }
}