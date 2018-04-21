public class Startup
{
    public static void Main()
    {
        Logger combatLog = new CombatLogger();
        Logger eventLog = new EventLogger();

        combatLog.SetSuccessor(eventLog);

        IAttackGroup attackGroup = new Group();

        attackGroup.AddMember(new Warrior("Pesho", 10, combatLog));
        attackGroup.AddMember(new Warrior("Gosho", 20, combatLog));
        
        var dragon = new Dragon("Blue-Eyed White Dragon", 100, 25, combatLog);

        IExecutor executor = new CommandExecutor();

        ICommand groupTarget = new GroupTargetCommand(attackGroup, dragon);
        groupTarget.Execute();

        ICommand groupAttack = new GroupAttackCommand(attackGroup);
        groupAttack.Execute();
    }
}