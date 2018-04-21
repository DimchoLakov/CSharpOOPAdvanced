public interface ISubordinate : INamable, IKillable
{
    string Action { get; }
    
    void ReactToAttack();
}