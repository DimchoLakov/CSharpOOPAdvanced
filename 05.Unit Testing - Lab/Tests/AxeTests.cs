using System;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Tests
{
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private IWeapon axe;
        private ITarget dummy;


        [SetUp]
        public void TestInitialize()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            this.axe.Attack(dummy);

            int axeDurabilityPointsAfterAttack = axe.DurabilityPoints;

            Assert.AreNotEqual(AxeDurability, axeDurabilityPointsAfterAttack, "Axe durability points doesn't change!");
        }

        [Test]
        public void AttackWithBrokenAxe()
        {
            this.axe.Attack(this.dummy);
            this.axe.Attack(this.dummy);

            Assert.That(() => axe.Attack(this.dummy), Throws.Exception.With.Message.EqualTo("Axe is broken."));
        }
    }
}
