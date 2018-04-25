using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    IHarvester IHarvesterFactory.GenerateHarvester(IList<string> args)
    {
        string type = args[0];

        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type harvesterType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        return (IHarvester)Activator.CreateInstance(harvesterType, id, oreOutput, energyReq);
    }
}