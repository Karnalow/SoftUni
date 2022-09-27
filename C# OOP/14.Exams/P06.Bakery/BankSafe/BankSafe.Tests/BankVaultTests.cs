using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Ivan", "7275");
        }

        [Test]
        public void WhenCellDoesNotExistShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("no item", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellIsAlreadyTakenShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Hristo", "2323"));
            });

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void WhenItemIsAlreadyExistShouldThrowException()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B2", item);
            });

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void AddItemMethodShouldReturnCorrectMessage()
        {        
            string result = vault.AddItem("A2", item);
            
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenTryToRemoveCellDoesNotExistShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A100", item);
            });

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenItemDoesNotExistShouldThrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", new Item("Hristo", "2323"));
            });

            Assert.AreEqual(ex.Message, $"Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldWorkCorrect()
        {
            vault.AddItem("A2", item);
            string result = vault.RemoveItem("A2", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}