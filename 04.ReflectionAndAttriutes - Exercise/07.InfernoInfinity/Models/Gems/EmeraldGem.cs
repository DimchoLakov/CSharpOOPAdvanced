public class EmeraldGem : Gem
{
    public EmeraldGem(string name, Clarity clarity) : base(name, clarity)
    {
        this.Strength = 1;
        this.Agility = 4;
        this.Vitality = 9;
        this.IncreaseStats();
    }
}