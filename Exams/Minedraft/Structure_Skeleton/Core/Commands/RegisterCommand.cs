using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string type = this.Arguments[0];

        string result = string.Empty;

        var argsToSend = this.Arguments.Skip(1).ToList();

        if (!int.TryParse(this.Arguments[2], out int a))
        {
            throw new ArgumentException("Invalid id!");
        }

        if (type == "Harvester")
        {
            result = this.harvesterController.Register(argsToSend);
        }
        else if (type == "Provider")
        {
            result = this.providerController.Register(argsToSend);
        }

        return result;
    }
}