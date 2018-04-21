using System;
using System.Linq;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();

        var tokens = input.Split();

        ListIterator listIterator;

        try
        {
            listIterator = new ListIterator(tokens.Skip(1).ToArray());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        while (input != "END")
        {
            tokens = input.Split();

            var result = string.Empty;

            var command = tokens[0];
            
            switch (command)
            {
                case "Move":
                    result = listIterator.Move().ToString();
                    break;
                case "HasNext":
                    result = listIterator.HasNext().ToString();
                    break;
                case "Print":
                    try
                    {
                        listIterator.Print();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        Console.WriteLine(ioe.Message);
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }

            input = Console.ReadLine();
        }
    }
}