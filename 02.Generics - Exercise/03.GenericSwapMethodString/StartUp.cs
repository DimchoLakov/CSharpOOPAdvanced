using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Box<string>> boxList = new List<Box<string>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var box = new Box<string>(Console.ReadLine());

            boxList.Add(box);
        }

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = indexes[0];
        int secondIndex = indexes[1];

        SwapElements(boxList, firstIndex, secondIndex);

        boxList.ForEach(Console.WriteLine);
    }

    static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
    {
        T temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    } 
}