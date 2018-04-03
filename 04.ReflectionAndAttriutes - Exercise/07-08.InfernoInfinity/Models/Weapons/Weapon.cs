using System.Linq;

[MyCustom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", new[] { "Pesho", "Svetlio" })]
public abstract class Weapon : IWeapon
{
    private int minDamage;
    private int maxDamage;
    protected Weapon(string name, Rarity rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
        this.Sockets = new IGem[this.NumberOfSockets];
        this.MinDamage = 1;
        this.MaxDamage = 1;
        this.Strength = 0;
        this.Agility = 0;
        this.Vitality = 0;
    }

    public Rarity Rarity { get; protected set; }
    public int MinDamage
    {
        get { return this.Strength * 2 + this.Agility + this.minDamage; }
        protected set { this.minDamage = value; }
    }

    public int MaxDamage
    {
        get { return this.Strength * 3 + this.Agility * 4 + this.maxDamage; }
        protected set { this.maxDamage = value; }
    }
    public virtual int NumberOfSockets { get; protected set; }
    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Vitality { get; private set; }
    public IGem[] Sockets { get; private set; }
    public string Name { get; private set; }

    public void AddGem(int index, IGem gem)
    {
        this.Sockets[index] = gem;
        this.SetStats();
    }

    public void RemoveGem(int index)
    {
        this.Sockets[index] = null;

        this.SetStats();
    }

    private void SetStats()
    {
        this.Agility = this.Sockets.Where(s => s != null).Sum(a => a.Agility);
        this.Strength = this.Sockets.Where(s => s != null).Sum(s => s.Strength);
        this.Vitality = this.Sockets.Where(s => s != null).Sum(v => v.Vitality);
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}