using _04.FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04.FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [Test]
        [TestCase("Ivan", 50, 70)]
        [TestCase("Hristo", 67, 20)]
        [TestCase("Gosho", 10, 5)]
        [TestCase("Angel", 1, 0)]
        public void CtorShouldSetEverytingIfDataIsValid
            (string name, int damage, int health)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, health);

            //Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(health, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void CtorShouldThrowArgumentExceptionForInvalidName(string name)
        {
            //Arrange & Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, 40, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-54)]
        public void CtorShouldThrowArgumentExceptionForInvalidDamage(int damage)
        {
            //Arrange & Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", damage, 50));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-54)]
        public void CtorShouldThrowArgumentExceptionForInvalidHealth(int health)
        {
            //Arrange & Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 40, health));
        }

        [Test]
        [TestCase("Ivan", 20, 50, "Hristo", 40, 50)]
        [TestCase("Ivan", 20, 50, "Hristo", 40, 50)]
        public void AttackMethodShouldThrowExceptionWhenHPisBelowOrEqual30
            (string name, int health, int damage,
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Ivan", 50, 40, "Hristo", 50, 90)]
        public void AttackMethodShouldThrowExceptionWhenDamageIsBelowThanEnemyDamage
            (string name, int health, int damage,
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            Assert.Throws<InvalidOperationException>
                (() => myWarrior.Attack(enemyWarrior));
        }

        [Test]
        [TestCase("Ivan", 100, 100, "Hristo", 50, 70)]
        public void AttackMethodShouldReduceWarriorHp
            (string name, int health, int damage,
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            myWarrior.Attack(enemyWarrior);

            int expectedHp = health - enemyDamage;
            int resultHp = myWarrior.HP;

            Assert.AreEqual(expectedHp, resultHp);
        }

        [Test]
        [TestCase("Ivan", 100, 100, "Hristo", 50, 70)]
        public void AttackMethodShouldSetEnemyWarriorHpTo0IfOurDamageIsBiggerThanEnemyHealth
            (string name, int health, int damage,
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            myWarrior.Attack(enemyWarrior);

            int expectedHp = 0;
            int resultHp = enemyWarrior.HP;

            Assert.AreEqual(expectedHp, resultHp);
        }

        [Test]
        [TestCase("Ivan", 100, 100, "Hristo", 120, 50)]
        public void AttackMethodShouldReduceEnemyHpIfOurDamageIsSmallerThatEnemyHp
            (string name, int health, int damage,
            string enemyName, int enemyHealth, int enemyDamage)
        {
            Warrior myWarrior = new Warrior(name, damage, health);
            Warrior enemyWarrior = new Warrior(enemyName, enemyDamage, enemyHealth);

            myWarrior.Attack(enemyWarrior);

            int expectedHp = enemyHealth - damage;
            int resultHp = enemyWarrior.HP;

            Assert.AreEqual(expectedHp, resultHp);
        }
    }
}
