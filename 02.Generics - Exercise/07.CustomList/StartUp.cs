using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        CustomList<string> myCustomList = new CustomList<string>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split();

            string command = tokens[0];

            string result = string.Empty;

            switch (command)
            {
                case "Add":
                    myCustomList.Add(tokens[1]);
                    break;
                case "Remove":
                    myCustomList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    result = myCustomList.Contains(tokens[1]).ToString();
                    break;
                case "Swap":
                    myCustomList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    result = myCustomList.CountGreaterThan(tokens[1]).ToString();
                    break;
                case "Max":
                    result = myCustomList.Max().ToString();
                    break;
                case "Min":
                    result = myCustomList.Min().ToString();
                    break;
                case "Print":
                    PrintElements(myCustomList);
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
        
    }

    private static void PrintElements(CustomList<string> myCustomList)
    {
        foreach (var item in myCustomList.Items)
        {
            Console.WriteLine(item);
        }
    }
}