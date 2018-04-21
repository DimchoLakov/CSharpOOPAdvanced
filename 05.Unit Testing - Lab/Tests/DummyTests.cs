using NUnit.Framework;
using Skeleton.Contracts;

namespace Tests
{
    public class DummyTests
    {
        private const int DummyHealth = 15;
        private const int DummyXP = 20;
        private const int AttackHitPoints = 14;
        private ITarget dummy;


        [SetUp]
        public void DummyInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            this.dummy.TakeAttack(AttackHitPoints);

            //Assert.That(dummyHealthAfterAttack, Is.EqualTo(1));
            Assert.AreNotEqual(DummyHealth, this.dummy.Health, "Dummy health doesn't change!");
        }

        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            this.dummy.TakeAttack(DummyHealth);
            
            Assert.That(() => this.dummy.TakeAttack(DummyHealth), Throws.Exception.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            this.dummy.TakeAttack(DummyHealth);
            Assert.AreEqual(this.dummy.GiveExperience(), DummyXP);
        }

        [Test]
        public void AliveDummyCannotGiveXp()
        {
            Assert.That(() => this.dummy.GiveExperience(), Throws.Exception.With.Message.EqualTo("Target is not dead."));
        }
    }
}
