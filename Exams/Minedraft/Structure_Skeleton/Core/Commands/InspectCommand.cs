using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id;

        if (!int.TryParse(this.Arguments[0], out id))
        {
            return string.Format(OutputMessages.NoEntityFound, this.Arguments[0]);
        }

        var harvController = (HarvesterController)this.harvesterController;

        IEntity entity = harvController.Entities.FirstOrDefault(h => h.ID == id);

        if (entity == null)
        {
            var provController = (ProviderController)this.providerController;
            entity = provController.Entities.FirstOrDefault(p => p.ID == id);
        }

        if (entity == null)
        {
            return string.Format(OutputMessages.NoEntityFound, id);
        }

        return entity.ToString();
    }
}