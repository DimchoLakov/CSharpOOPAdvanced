using System;

public class InfinityHarvester : Harvester
{
    private const int InitialOreOutputDivider = 10;
    private const double InitialDurability = 1000d;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput = oreOutput / InitialOreOutputDivider;
    }

    public override double Durability
    {
        get { return this.durability; }
        protected set { this.durability = Math.Max(0, value); }
    }


    public override void Broke()
    {
        this.Durability = InitialDurability;
    }
}