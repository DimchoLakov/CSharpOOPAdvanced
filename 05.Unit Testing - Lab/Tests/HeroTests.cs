using System;
using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Tests
{
    public class HeroTests
    {
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsXAfterAttackpIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(f => f.Health).Returns(0);
            fakeTarget.Setup(f => f.GiveExperience()).Returns(20);
            fakeTarget.Setup(f => f.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            fakeWeapon.Setup(w => w.Attack(fakeTarget.Object));

            Hero hero = new Hero("Pesho", fakeWeapon.Object);
            hero.Attack(fakeTarget.Object);

            Assert.That(hero.Experience, Is.EqualTo(20));

            //FakeTarget fakeTarget = new FakeTarget();
            //FakeWeapon fakeWeapon = new FakeWeapon();

            //Hero hero = new Hero(HeroName, fakeWeapon);
            //int heroInitialExperience = hero.Experience;

            //hero.Attack(fakeTarget);

            //int heroExperienceAfterAttack = hero.Experience;
            //Assert.That(heroExperienceAfterAttack > heroInitialExperience, "Not gaining Experience");
        }
    }
}