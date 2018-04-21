using System;
using Skeleton.Contracts;

public class StartUp
{
    public static void Main()
    {
        IWeapon axe = new Axe(2, 2);
        ITarget dummy = new Dummy(20, 20);

        int initDurability = axe.DurabilityPoints;

        axe.Attack(dummy);

        int afterDurability = axe.DurabilityPoints;

        Console.WriteLine($"Init durability: {initDurability}");
        Console.WriteLine($"After durability: {afterDurability}");
    }
}
