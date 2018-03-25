using System;

public class StartUp
{
    public static void Main()
    {
        string[] strings = ArrayCreator.Create(5, "some data");
        int[] integers = ArrayCreator.Create(10, 33);

        foreach (var s in strings)
        {
            Console.WriteLine(s);
        }

        foreach (var integer in integers)
        {
            Console.WriteLine(integer);
        }
    }
}