namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CtorInitCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumation, fuelConsumation);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(null, "asd", 2, 5)]
        [TestCase("asd", null, 5, 2)]
        [TestCase("asd", "dsa", 0, 10)]
        [TestCase("asd", "dsa", -1, 10)]
        [TestCase("asd", "dsa", 10, 0)]
        [TestCase("asd", "dsa", 10, -1)]
        public void AllPropThrowArgumentExceptionWhenTheyAreInvalid
            (string make, string model, double fuelConsumation, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumation, fuelCapacity));
        }

        [Test]
        public void RefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            car.Refuel(10);

            double expectedFuelAmount = 10;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void RefuelCapsCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            double tryToFuelAmout = 1000;

            car.Refuel(tryToFuelAmout);

            double expectedFuelAmount = fuelCapacity;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelArgumentExceptionNegative(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            Assert.Throws<ArgumentException>
                (() => car.Refuel(inputAmount));
        }

        [Test]
        public void DriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(1, 100)]
        [TestCase(1, 51)]
        [TestCase(9, 500)]
        [TestCase(8, 444)]
        [TestCase(10, 501)]
        [TestCase(11, 666)]
        public void DriveThrowInvalidOperationExceptionNotEnoughFuel
            (double refuelAmount, double driveDistance)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumation = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumation, fuelCapacity);

            car.Refuel(refuelAmount);

            Assert.Throws<InvalidOperationException>
                (() => car.Drive(driveDistance));
        }
    }
}