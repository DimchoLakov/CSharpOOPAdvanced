using System;
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    private const string SystemShutdown = "System Shutdown";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string result = SystemShutdown + Environment.NewLine;
        result += string.Format(OutputMessages.TotalEnergyProduced, this.providerController.TotalEnergyProduced) + Environment.NewLine;
        result += string.Format(OutputMessages.TotalMinedPlumbusOre, this.harvesterController.TotalOreProduced);

        return result;
    }
}