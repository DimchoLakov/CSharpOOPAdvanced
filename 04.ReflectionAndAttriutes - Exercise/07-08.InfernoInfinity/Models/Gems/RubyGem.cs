public class RubyGem : Gem
{
    public RubyGem(string name, Clarity clarity) : base(name, clarity)
    {
        this.Strength = 7;
        this.Agility = 2;
        this.Vitality = 5;
        this.IncreaseStats();
    }
}