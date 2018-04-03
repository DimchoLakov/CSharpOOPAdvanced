using System;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(Rarity rarity, string type, string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var weaponType = assembly.GetType(type + "Weapon");

        if (weaponType == null)
        {
            throw new ArgumentException($"Invalid weapon!");
        }

        bool isAssignable = typeof(IWeapon).IsAssignableFrom(weaponType);

        if (!isAssignable)
        {
            throw new ArgumentException($"{type} is not a weapon!");
        }

        return (IWeapon)Activator.CreateInstance(weaponType, new object[] { name, rarity });
    }
}