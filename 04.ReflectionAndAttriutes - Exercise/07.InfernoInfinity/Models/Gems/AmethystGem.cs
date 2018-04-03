public class AmethystGem : Gem
{
    public AmethystGem(string name, Clarity clarity) : base(name, clarity)
    {
        this.Strength = 2;
        this.Agility = 8;
        this.Vitality = 4;
        this.IncreaseStats();
    }
}