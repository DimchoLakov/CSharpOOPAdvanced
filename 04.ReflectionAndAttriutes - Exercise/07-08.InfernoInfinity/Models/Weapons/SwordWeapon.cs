public class SwordWeapon : Weapon
{
    public SwordWeapon(string name, Rarity rarity) : base(name, rarity)
    {
        this.MinDamage = 4 * (int)this.Rarity;
        this.MaxDamage = 6 * (int)this.Rarity;
    }

    public override int NumberOfSockets => 3;
}