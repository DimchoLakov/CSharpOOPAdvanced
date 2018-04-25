using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const string FullMode = "Full";

    private readonly IEnergyRepository energyRepository;
    private readonly List<IHarvester> harvesters;
    private readonly IHarvesterFactory harvesterFactory;
    private string mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.mode = FullMode;
        this.TotalOreProduced = 0;
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(OutputMessages.SuccessfullRegistration, 
            harvester.GetType().Name);
    }

    public string Produce()
    {
        double totalEnergyRequirement = this.TotalEnergyRequirement;

        double oreProducedToday = 0d;

        if (this.energyRepository.TakeEnergy(totalEnergyRequirement))
        {
            oreProducedToday = this.harvesters.Sum(h => h.Produce());
            if (this.mode == "Half")
            {
                oreProducedToday *= 0.5;
            }
            else if (this.mode == "Energy")
            {
                oreProducedToday *= 0.2;
            }
        }
        
        this.TotalOreProduced += oreProducedToday;

        return String.Format(OutputMessages.OreProducedToday, oreProducedToday);
    }

    private double TotalEnergyRequirement
    {
        get
        {
            if (this.mode == "Half")
            {
                return this.harvesters.Sum(h => h.EnergyRequirement) * 0.5;
            }

            if (this.mode == "Energy")
            {
                return this.harvesters.Sum(h => h.EnergyRequirement) * 0.2;
            }

            return this.harvesters.Sum(h => h.EnergyRequirement);
        }
    }

    public double TotalOreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        var reminder = new List<IHarvester>();
        foreach (var provider in this.harvesters)
        {
            try
            {
                provider.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(provider);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }
        return string.Format(OutputMessages.ModeChanged, this.mode);
    }
}