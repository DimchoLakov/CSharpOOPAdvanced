using Skeleton.Contracts;

namespace Tests
{
    public class FakeTarget : ITarget
    {
        public int Health { get; private set; }
        public int Experience { get; }
        public void TakeAttack(int attackPoints)
        {
            //this.Health -= attackPoints;
        }

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }
    }
}
