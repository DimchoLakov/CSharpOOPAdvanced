using System;

public class RetireCommand : Command
{
    [Inject]
    private IRepository repository;

    public RetireCommand(string[] data, IRepository repository) : base(data)
    {
        this.Repository = repository;
    }

    public IRepository Repository
    {
        get => this.repository;
        private set => this.repository = value;
    }

    public override string Execute()
    {
        string unitType = this.Data[1];

        string result = string.Empty;

        try
        {
            this.Repository.RemoveUnit(unitType);
            result = $"{unitType} retired!";
        }
        catch (ArgumentException ae)
        {
            result = ae.Message;
        }

        return result;
    }
}