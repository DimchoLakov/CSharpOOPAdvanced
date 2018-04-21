using System;
using Skeleton.Contracts;

// Axe durability drop with 5 
public class Axe : IWeapon
{
    private int attackPoints;
    private int durabilityPoints;

    public Axe(int attack, int durability)
    {
        this.AttackPoints = attack;
        this.DurabilityPoints = durability;
    }

    public int AttackPoints
    {
        get { return this.attackPoints; }
        private set { this.attackPoints = value; }
    }

    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
        private set { this.durabilityPoints = value; }
    }

    public void Attack(ITarget target)
    {
        if (this.DurabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.attackPoints);
        this.DurabilityPoints -= 1;
    }
}
