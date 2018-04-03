using System.Collections.Generic;
using System.Linq;

public class WeaponRepository : IReposirtory
{
    private List<IWeapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<IWeapon>();
    }

    public List<IWeapon> Weapons
    {
        get { return this.weapons; }
        private set { this.weapons = value; }
    }

    public void Add(IWeapon weapon)
    {
        this.Weapons.Add(weapon);
    }

    public IWeapon GetWeapon(string weaponName)
    {
        return this.Weapons.FirstOrDefault(w => w.Name == weaponName);
    }
}