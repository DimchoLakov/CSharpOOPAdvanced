using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController) : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        return this.providerController.Repair(double.Parse(this.Arguments[0]));
    }
}