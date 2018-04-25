using System;

public abstract class Harvester : IHarvester
{
    private const double InitialDurability = 1000d;
    private const double DurabilityDecreaser = 100d;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; private set; }
    public virtual double Durability { get; protected set; }
    public double Produce()
    {
        return this.OreOutput;
    }

    public virtual void Broke()
    {
        if (this.Durability <= 0)
        {
            throw new ArgumentException("Harvester already broken!");
        }
        this.Durability -= DurabilityDecreaser;
    }

    public double OreOutput { get; protected set; }
    public double EnergyRequirement { get; protected set; }

    public override string ToString()
    {
        string result = $"{this.GetType().Name}" + Environment.NewLine;
        result += $"Durability: {this.Durability}";

        return result;
    }
}