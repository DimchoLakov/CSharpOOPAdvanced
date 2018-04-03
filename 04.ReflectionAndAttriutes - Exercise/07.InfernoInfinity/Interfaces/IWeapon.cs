public interface IWeapon : IBaseStats, IAdditionalStats
{
    string Name { get; }

    void AddGem(int index, IGem gem);

    void RemoveGem(int index);
}