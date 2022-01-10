using NUnit.Framework;
using P01.TestAxe.Models;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyIsDummyLosesHealth()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreNotEqual(10, dummy.Health);
        }

        [Test]
        public void DummyCanGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            if (dummy.IsDead())
            {
                Assert.AreEqual(10, dummy.GiveExperience());
            }
        }

        [Test]
        public void DummyIfDummyIsDeadCanNotBeAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            if (dummy.IsDead())
            {
                throw new System.Exception("Dummy is dead.");
            }
            else
            {
                axe.Attack(dummy);
            }
        }

        [Test]
        public void DummyIfDummyIsAliveCanNotGiveXP()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            if (!dummy.IsDead())
            {
                throw new System.Exception("Dummy is alive and cant give XP");
            }
        }
    }
}
