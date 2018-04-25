public class SonicHarvester : Harvester
{
    private const int InitialEnergyRequirementDivider = 2;
    private const int InitialDurabilityDecreaser = 300;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement / InitialEnergyRequirementDivider;
        this.Durability -= InitialDurabilityDecreaser;
    }
}