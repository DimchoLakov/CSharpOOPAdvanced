using System;

public class CreateCommand : Command
{
    [Inject]
    private IReposirtory repository;
    [Inject]
    private IWeaponFactory weaponFactory;

    public CreateCommand(string[] data, IReposirtory reposirtory, IWeaponFactory weaponFactory) : base(data)
    {
        this.repository = reposirtory;
        this.weaponFactory = weaponFactory;
    }

    public override void Execute()
    {
        var weaponTokens = Data[1].Split();
        var rarityType = weaponTokens[0];
        var weaponType = weaponTokens[1];
        var weaponName = Data[2];

        Rarity rarity;
        Enum.TryParse(rarityType, out rarity);

        if (rarity == 0)
        {
            throw new ArgumentException("Invalid Rarity Type!");
        }
        
        var weapon = this.weaponFactory.CreateWeapon(rarity, weaponType, weaponName);

        this.repository.Add(weapon);
    }
}