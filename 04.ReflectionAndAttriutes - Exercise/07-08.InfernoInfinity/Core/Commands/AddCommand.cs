using System;

public class AddCommand : Command
{
    [Inject]
    private IReposirtory repository;
    [Inject]
    private IGemFactory gemFactory;
    public AddCommand(string[] data, IReposirtory repository, IGemFactory gemFactory) : base(data)
    {
        this.repository = repository;
        this.gemFactory = gemFactory;
    }

    public IReposirtory Reposirtory
    {
        get => this.repository;
        private set => this.repository = value;
    }

    public override void Execute()
    {
        var weaponName = Data[1];
        var weapon = this.Reposirtory.GetWeapon(weaponName);

        if (weapon == null)
        {
            throw new ArgumentException($"{weapon} does not exist!");
        }

        var addTokens = Data[3].Split();
        var clarityType = addTokens[0];
        var gemName = addTokens[1];

        Clarity clarity;
        Enum.TryParse(clarityType, out clarity);

        if (clarity == 0)
        {
            throw new ArgumentException($"Invalid Clarity Type!");
        }

        var gem = this.gemFactory.CreateGem(gemName, clarity);
        int index = int.Parse(Data[2]);

        try
        {
            weapon.AddGem(index, gem);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}