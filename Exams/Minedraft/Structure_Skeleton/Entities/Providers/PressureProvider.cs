public class PressureProvider : Provider
{
    private const int InitialEnergyOutputMultiplier = 2;
    private const double DurabilityDecreaser = 300;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput = energyOutput * InitialEnergyOutputMultiplier;
        this.Durability -= DurabilityDecreaser;
    }
}