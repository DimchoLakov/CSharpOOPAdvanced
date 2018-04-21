using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        IKing king = SetupKing();
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] tokens = input.Split();

            string command = tokens[0];

            if (command == "Attack")
            {
                king.GetAttacked();
            }
            else if (command == "Kill")
            {
                string subordinateName = tokens[1];

                ISubordinate subordinate = king.Subordinates.First(s => s.Name == subordinateName);
                subordinate.Die();
            }

            input = Console.ReadLine();
        }
    }

    private static IKing SetupKing()
    {
        string kingsName = Console.ReadLine();

        IKing king = new King(kingsName, new List<ISubordinate>());

        string[] royalGuards = Console.ReadLine().Split();

        foreach (string royalGuard in royalGuards)
        {
            king.AddSubordinate(new RoyalGuard(royalGuard));
        }

        string[] footmen = Console.ReadLine().Split();

        foreach (string footman in footmen)
        {
            king.AddSubordinate(new Footman(footman));
        }

        return king;
    }
}