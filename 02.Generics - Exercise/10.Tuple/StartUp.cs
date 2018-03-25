using System;

public class StartUp
{
    public static void Main()
    {
        string[] tokens = ReadInput();
        tokens[0] = $"{tokens[0]} {tokens[1]}";
        var firstTuple = new Tuple<string, string>(tokens[0], tokens[2]);
        PrintTuple(firstTuple);

        tokens = ReadInput();
        var secondTuple = new Tuple<string, int>(tokens[0], int.Parse(tokens[1]));
        PrintTuple(secondTuple);

        tokens = ReadInput();
        var thirdTuple = new Tuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));
        PrintTuple(thirdTuple);

    }

    private static void PrintTuple<T1, T2>(Tuple<T1, T2> tuple)
    {
        Console.WriteLine($"{tuple.FirstItem} -> {tuple.SecondItem}");
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split();
    }
}