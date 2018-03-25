using System;
public class StartUp
{
    public static void Main()
    {
        Box<int> box = new Box<int> {1, 2, 3};
        Console.WriteLine(box.Remove());
        box.Add(4);
        box.Add(5);
        Console.WriteLine(box.Remove());
        Console.WriteLine(box.Count);
    }
}