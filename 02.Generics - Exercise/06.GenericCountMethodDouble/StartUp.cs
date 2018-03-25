using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var boxList = new List<Box<double>>();

        for (int i = 0; i < n; i++)
        {
            var box = new Box<double>(double.Parse(Console.ReadLine()));
            boxList.Add(box);
        }

        var boxToCompareTo = new Box<double>(double.Parse(Console.ReadLine()));

        int result = CompareElementsWithGivenElement(boxList, boxToCompareTo);

        Console.WriteLine(result);
    }

    static int CompareElementsWithGivenElement<T>(List<T> list, T item)
    {
        int count = 0;
        foreach (T box in list)
        {
            var firstBox = box as Box<double>;
            var secondBox = item as Box<double>;
            int result = firstBox.CompareTo(secondBox);
            if (result > 0)
            {
                count++;
            }
        }
        return count;
    }
}