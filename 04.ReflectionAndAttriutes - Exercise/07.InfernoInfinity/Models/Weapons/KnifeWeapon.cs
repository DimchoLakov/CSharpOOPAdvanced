public class KnifeWeapon : Weapon
{
    public KnifeWeapon(string name, Rarity rarity) : base(name, rarity)
    {
        this.MinDamage = 3 * (int)this.Rarity;
        this.MaxDamage = 4 * (int)this.Rarity;
    }

    public override int NumberOfSockets => 2;
}