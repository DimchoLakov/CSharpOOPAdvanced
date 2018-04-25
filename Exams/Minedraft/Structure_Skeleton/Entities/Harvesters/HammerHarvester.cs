public class HammerHarvester : Harvester
{
    private const int InitialEnergyRequirementMultiplier = 2;
    private const int InitialOreOutputMultiplier = 4;

    public HammerHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement * InitialEnergyRequirementMultiplier;
        this.OreOutput = oreOutput * InitialOreOutputMultiplier;
    }
}