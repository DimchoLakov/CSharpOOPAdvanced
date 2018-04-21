using System;

public class Startup
{
    public static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string input = Console.ReadLine();

        while (input != "End")
        {
            dispatcher.Name = input;

            input = Console.ReadLine();
        }
    }
}