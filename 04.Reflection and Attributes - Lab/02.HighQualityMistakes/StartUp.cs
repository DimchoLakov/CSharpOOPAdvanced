using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers(nameof(Hacker));
        Console.WriteLine(result);
    }
}