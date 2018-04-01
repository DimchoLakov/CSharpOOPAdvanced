using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string result = spy.CollectGettersAndSetters(nameof(Hacker));
        Console.WriteLine(result);
    }
}