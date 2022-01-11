namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(3)]
        [TestCase(12)]
        [TestCase(16)]
        [TestCase(0)]
        public void AddMethodShouldAddNewElementsWhileCountIsLessThan16(int count)
        {
            //Arrange
            Database database = new Database();

            //Act
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldTrowNewExceptionWhenItemsAreAbove16()
        {
            //Arrange
            Database database = new Database();

            //Act
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(5));
        }

        [Test]
        [TestCase(1, 4)]
        [TestCase(1, 15)]
        [TestCase(1, 16)]
        public void CtorShouldAddAllItemsWhileTheyAreBelow16(int start, int count)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();

            //Act
            Database database = new Database(elements);

            //Assert
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void CtorShouldThrowExceptionWhenItemsAreAbove0(int start, int count)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();

            //Act
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(1, 10, 3, 7)]
        [TestCase(1, 5, 4, 1)]
        public void RemoveMethodShouldRemoveElementsWhenTheyAreAbove0
            (int start, int count, int toRemove, int result)
        {
            //Arrange
            int[] elements = Enumerable.Range(start, count).ToArray();

            Database database = new Database(elements);

            //Act
            for (int i = 0; i < toRemove; i++)
            {
                database.Remove();
            }

            //Assert
            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenElementsAre0()
        {
            //Arrange
            Database database = new Database();

            //Act
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllValidItems()
        {
            //Arrange
            Database database = new Database(1, 2, 3);

            //Act
            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchData = database.Fetch();

            //Assert
            int[] expectedData = new int[] { 1, 2 };

            Assert.AreEqual(expectedData, fetchData);
        }
    }
}
