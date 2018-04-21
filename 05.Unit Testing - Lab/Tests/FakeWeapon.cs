using Skeleton.Contracts;

namespace Tests
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 2;
        public int DurabilityPoints => 3;
        public void Attack(ITarget target)
        {
            //target.TakeAttack(this.AttackPoints);
        }
    }
}
