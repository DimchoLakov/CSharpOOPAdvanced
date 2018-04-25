using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string ShutdownCommand = "Shutdown";

    private readonly ICommandInterpreter commandInterpreter;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            string input = this.reader.ReadLine().Trim();

            List<string> args = input.Split().ToList();

            string result = commandInterpreter.ProcessCommand(args);

            this.writer.WriteLine(result);

            if (input == ShutdownCommand)
            {
                Environment.Exit(0);
            }
        }
    }
}
