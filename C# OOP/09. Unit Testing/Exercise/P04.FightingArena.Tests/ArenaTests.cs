using _04.FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void CtorShouldInitializeAllValues()
        {
            //Arrange & Act
            Arena arena = new Arena();

            //Assert
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorIfDoesntExists()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ivan", 50, 80);
            Warrior warrior2 = new Warrior("Hristo", 150, 280);
            Warrior warrior3 = new Warrior("Angel", 350, 480);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);

            Assert.AreEqual(3, arena.Count);

            bool warriorExist = arena.Warriors.Contains(warrior);
            bool warriorExist2 = arena.Warriors.Contains(warrior2);
            bool warriorExist3 = arena.Warriors.Contains(warrior3);

            Assert.True(warriorExist);
            Assert.True(warriorExist2);
            Assert.True(warriorExist3);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionForDubpicatedWarrior()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ivan", 50, 80);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Enroll(warrior));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidWarriors()
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Ivan", "Hristo"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Hristo", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Ivan", "Hristo"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDefender()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Ivan", 40, 70);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>
                (() => arena.Fight("Ivan", "Hristo"));
        }

        [Test]
        public void FightShouldReduceHP()
        {
            Arena arena = new Arena();

            Warrior attacker = new Warrior("Ivan", 100, 50);
            Warrior defender = new Warrior("Hristo", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Ivan", "Hristo");

            Warrior warriorAttacker = arena.Warriors
                .FirstOrDefault(x => x.Name == "Ivan");
            Warrior warriorDefender = arena.Warriors
                .FirstOrDefault(x => x.Name == "Hristo");

            Assert.AreEqual(0, warriorAttacker.HP);
            Assert.AreEqual(0, warriorDefender.HP);
        }
    }
}
