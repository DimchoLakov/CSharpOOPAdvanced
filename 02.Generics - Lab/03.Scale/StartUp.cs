using System;

public class StartUp
{
    public static void Main()
    {
        var scale = new Scale<char>('b', 'c');

        Console.WriteLine(scale.GetHeavier());
    }
}