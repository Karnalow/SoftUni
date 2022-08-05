namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        [TestCase("Goldie")]
        [TestCase("Stewie")]
        public void FishCtorShouldInitializeAllValues(string name)
        {
            Fish fish = new Fish(name);
            fish.Available = true;

            Assert.IsNotNull(fish.Name);
            Assert.IsNotNull(fish.Available);
        }

        [Test]
        [TestCase("Ivan", 10)]
        [TestCase("Georgi", 8)]
        public void AquariumCtorShouldInitializeAllValues(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.IsNotNull(aquarium.Name);
            Assert.IsNotNull(aquarium.Capacity);
        }

        [Test]
        [TestCase(null, 10)]
        [TestCase("", 8)]
        public void NamePropShouldThrowExceptionIfNameInvalid(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        [TestCase("Ivan", -1)]
        [TestCase("Georgi", -10)]
        public void CapacityPropShouldThrowExceptionIfCapacityInvalid(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        [TestCase("Ivan", 10, "Goldie")]
        [TestCase("Georgi", 8, "Stewie")]
        public void AddMethodShouldAddFish(string aquariumName, int capacity, string fishName)
        { 
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);

            var expected = 1;
            var actual = aquarium.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Georgi", 0, "Stewie")]
        public void AddMethodShouldThrowExceptionIfThereIsNotCapacityLeft(string aquariumName, int capacity, string fishName)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fish = new Fish(fishName);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        [TestCase("Ivan", 10, "Goldie")]
        [TestCase("Georgi", 8, "Stewie")]
        public void RemoveFishMethodShouldRemoveFishByName(string aquariumName, int capacity, string fishName)
        {
            Aquarium aquarium = new Aquarium(aquariumName, capacity);
            Fish fish = new Fish(fishName);

            aquarium.Add(fish);
            aquarium.RemoveFish(fishName);

            Assert.Zero(aquarium.Count);
        }

        [Test]
        [TestCase("Ivan", 10, "Goldie")]
        [TestCase("Georgi", 8, "Stewie")]
        public void RemoveFishMethodShouldThrowExceptionIfFishIsNull(string aquariumName, int capacity, string fishName)
        {
            Assert.Throws<InvalidOperationException>(() => new Aquarium(aquariumName, capacity).RemoveFish(fishName));
        }

        [Test]
        [TestCase("Ivan", 10, "Goldie")]
        [TestCase("Georgi", 8, "Stewie")]
        public void SellFishMethodShouldSellFish(string aquariumName, int capacity, string fishName)
        {
            Fish fish = new Fish(fishName);
            Aquarium aquarium = new Aquarium(aquariumName, capacity);

            aquarium.Add(fish);

            Assert.AreEqual(fish, aquarium.SellFish(fishName));
        }

        [Test]
        [TestCase("Ivan", 10, "Goldie")]
        [TestCase("Georgi", 8, "Stewie")]
        public void SellFishMethodShouldThrowExceptionIfFishIsNull(string aquariumName, int capacity, string fishName)
        {
            Assert.Throws<InvalidOperationException>(() => new Aquarium(aquariumName, capacity).SellFish(fishName));
        }
    }
}
