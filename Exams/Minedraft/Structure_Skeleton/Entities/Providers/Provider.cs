using System;

public abstract class Provider : IProvider
{
    private const int InitialDurabilityValue = 1000;
    private const double DurabilityDecreaser = 100d;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurabilityValue;
    }

    public int ID { get; private set; }
    public double Durability { get; protected set; }
    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        if (this.Durability <= 0)
        {
            throw new ArgumentException("Provider already broken!");
        }
        this.Durability -= DurabilityDecreaser;
    }

    public double EnergyOutput { get; protected set; }
    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        string result = $"{this.GetType().Name}" + Environment.NewLine;
        result += $"Durability: {this.Durability}";

        return result;
    }
}