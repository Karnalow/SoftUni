using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void CounterIsZeroByDefault()
        {
            Assert.That(this.raceEntry.Counter, Is.Zero);
        }

        [Test]
        public void CounterIncreasesWhenAddingDriver()
        {
            this.raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("Audi", 180, 2.5)));

            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriverThrowsInvalidOperationExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverShouldThrowInvalidOperationExceptionIfDriverAlreadyExist()
        {
            this.raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("Audi", 180, 2.5)));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("BMW", 500, 5.0))));
        }

        [Test]
        public void AddDriverReturnsExpectedResultMessage()
        {
            string driverName = "Ivan";

            var actual = this.raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Audi", 180, 2.5)));
            var expected = $"Driver {driverName} added in race.";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowInvalidOperationExceptionIfDriversCountIsSmallerThanMinParticipantDrivers()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());

            this.raceEntry.AddDriver(new UnitDriver("Ivan", new UnitCar("Audi", 180, 2.5)));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerReturnsExpectedCalculatedResult()
        {
            int n = 10;
            double expected = 0;

            for (int i = 0; i < n; i++)
            {
                int horsePower = 180 + i;
                expected += horsePower;

                this.raceEntry.AddDriver(new UnitDriver($"Name-{i}", new UnitCar("Audi", horsePower, 2.5)));
            }

            expected /= n;

            double actual = this.raceEntry.CalculateAverageHorsePower();

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}