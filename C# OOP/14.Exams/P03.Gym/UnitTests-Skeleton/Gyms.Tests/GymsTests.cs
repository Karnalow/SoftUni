using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        [TestCase("Ivan Karnalov")]
        [TestCase("Hristo Slavchev")]
        [TestCase("Angel Nikolov")]
        public void AthleteCtorShouldInitializeAllValues(string fullName)
        {
            Athlete athlete = new Athlete(fullName);

            Assert.IsNotNull(athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        [TestCase("Noa", 100)]
        [TestCase("Titan", 300)]
        [TestCase("Ivan", 50)]
        public void GymCtorShouldInitializeAllValues(string name, int size)
        {
            Gym gym = new Gym(name, size);

            Assert.IsNotNull(gym.Name);
            Assert.IsNotNull(gym.Capacity);
        }

        [Test]
        [TestCase("", 100)]
        [TestCase(null, 300)]
        public void GymCtorShouldThrowArgumentNullExceptionForInvalidGymName
            (string name, int size)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, size));
        }

        [Test]
        [TestCase("Noa", -100)]
        [TestCase("Titan", -300)]
        [TestCase("Ivan", -50)]
        public void GymShouldThrowArgumentExceptionForInvalidCapacity
            (string name, int size)
        {
            Assert.Throws<ArgumentException>(() => new Gym(name, size));
        }

        [Test]
        [TestCase("Ivan Karnalov", "Noa", 100)]
        [TestCase("Hristo Slavchev", "Titan", 300)]
        [TestCase("Angel Nikolov", "Ivan", 50)]
        public void GymAddMethodShouldAddAthleteToCollection
            (string fullAthleteName, string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);
            Athlete athlete = new Athlete(fullAthleteName);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);

            Assert.AreEqual(4, gym.Count);
        }

        [Test]
        [TestCase("Ivan Karnalov", "Noa", 1)]
        public void GymAddMethodShouldThrowInvalidOperationExceptionIfGymIsFull
            (string fullAthleteName, string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);
            Athlete athlete = new Athlete(fullAthleteName);

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        [TestCase("Ivan Karnalov", "Noa", 1)]
        [TestCase("Hristo Slavchev", "Titan", 300)]
        [TestCase("Angel Nikolov", "Ivan", 50)]
        public void GymRemoveMethodShouldRemoveAthlete
            (string fullAthleteName, string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);
            Athlete athlete = new Athlete(fullAthleteName);

            gym.AddAthlete(athlete);
            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        [TestCase("Noa", 1)]
        [TestCase("Titan", 300)]
        [TestCase("Ivan", 50)]
        public void GymRemoveMethodShouldThrowInvalidOperationExceptionIfAthleteDoesNotExist
            (string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Pesho"));
        }

        [Test]
        [TestCase("Ivan Karnalov", "Noa", 1)]
        [TestCase("Hristo Slavchev", "Titan", 300)]
        [TestCase("Angel Nikolov", "Ivan", 50)]
        public void GymInjureAthleteMethodShouldReturnTrueIfAthleteExist
            (string fullAthleteName, string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);
            Athlete athlete = new Athlete(fullAthleteName);

            gym.AddAthlete(athlete);
            gym.InjureAthlete(fullAthleteName);

            Assert.IsTrue(athlete.IsInjured);
        }

        [Test]
        [TestCase("Ivan Karnalov", "Noa", 1)]
        [TestCase("Hristo Slavchev", "Titan", 300)]
        [TestCase("Angel Nikolov", "Ivan", 50)]
        public void GymInjureAthleteMethodThrowExceptionIfAthleteDoesNotExist
            (string fullAthleteName, string gymName, int gymSize)
        {
            Gym gym = new Gym(gymName, gymSize);
            Athlete athlete = new Athlete(fullAthleteName);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Pesho"));
        }
    }
}
