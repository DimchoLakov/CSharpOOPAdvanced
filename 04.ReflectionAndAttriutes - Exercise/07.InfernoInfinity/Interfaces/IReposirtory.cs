public interface IReposirtory
{
    void Add(IWeapon data);

    IWeapon GetWeapon(string weaponName);
}