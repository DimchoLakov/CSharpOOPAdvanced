using System;

public class StartUp
{
    public static void Main()
    {
        string[] tokens = ReadInput();
        tokens[0] = $"{tokens[0]} {tokens[1]}";
        var firstTuple = new Threeuple<string, string, string>(tokens[0], tokens[2], tokens[3]);
        PrintTuple(firstTuple);

        tokens = ReadInput();
        bool isDrunk = tokens[2] == "drunk";
        var secondTuple = new Threeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), isDrunk);
        PrintTuple(secondTuple);

        tokens = ReadInput();
        var thirdTuple = new Threeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);
        PrintTuple(thirdTuple);

    }

    private static void PrintTuple<T1, T2, T3>(Threeuple<T1, T2, T3> threeuple)
    {
        Console.WriteLine($"{threeuple.FirstItem} -> {threeuple.SecondItem} -> {threeuple.ThirdItem}");
    }

    private static string[] ReadInput()
    {
        return Console.ReadLine().Split();
    }
}