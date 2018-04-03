public interface IWeaponFactory
{
    IWeapon CreateWeapon(Rarity rarity, string type, string name);
}