public class AxeWeapon : Weapon
{
    public AxeWeapon(string name, Rarity rarity) : base(name, rarity)
    {
        this.MinDamage = 5 * (int)this.Rarity;
        this.MaxDamage = 10 * (int)this.Rarity;
    }

    public override int NumberOfSockets => 4;
}