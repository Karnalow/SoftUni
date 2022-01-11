using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        public Person pesho;
        public Person gosho;

        [SetUp]
        public void TestInit()
        {
            pesho = new Person(114560, "Pesho");
            gosho = new Person(447788556699, "Gosho");
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            Person[] expected = new Person[] { pesho, gosho };

            Database database = new Database(expected);

            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddShouldAddValidPerson()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);
            Person newPerson = new Person(554466, "Stamat");
            database.Add(newPerson);

            Person[] expected = new Person[] { pesho, gosho, newPerson };
            Person[] actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);
            Person newPerson = new Person(554466, "Gosho");

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddSameIdShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);
            Person newPerson = new Person(114560, "Stamat");

            Assert.That(() => database.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemove()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);
            database.Remove();


            Person[] expected = new Person[] { pesho };
            Person[] actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            Person[] persons = new Person[] { };
            Database database = new Database(persons);

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Person expected = pesho;
            Person actual = database.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Assert.That(() => database.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Assert.That(() => database.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Person expected = pesho;
            Person actual = database.FindById(114560);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Assert.That(() => database.FindById(558877), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            Person[] persons = new Person[] { pesho, gosho };
            Database database = new Database(persons);

            Assert.That(() => database.FindById(-5), Throws.Exception);
        }

        [Test]
        [TestCase(1, "Pesho")]
        [TestCase(444, "Iva")]
        [TestCase(999, "Sxema")]
        [TestCase(444, "Rima")]
        [TestCase(111, "Yuna")]
        public void Person_SuccessfulDataPass(long id, string userName)
        {
            Person person = new Person(id, userName);

            long expectedId = id;
            long actualId = person.Id;
            string expectedUsername = userName;
            string actualUsername = person.UserName;

            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(16)]
        public void ExtendedDB_Constructor_CorrectAmountOfData(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            int expected = people.Length;
            int actual = expectedDatabase.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConstructorPersonShouldInitializeCollection()
        {
            Assert.IsNotNull(pesho);
        }

        [Test]
        public void ConstructorExtendedDBShouldInitializeCollection()
        {
            Person[] expected = new Person[] { pesho, gosho };

            Database database = new Database(expected);

            Assert.IsNotNull(database);
        }

        [Test]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(22)]
        [TestCase(555)]
        [TestCase(100)]
        [TestCase(1000)]
        public void AddRange_Throws_ArgumentException_WhenCountMoreThan16(int count)
        {
            Person[] data = new Person[count];

            Assert.Throws<ArgumentException>
                (() => new Database(data));
        }

        [Test]
        [TestCase(13)]
        [TestCase(15)]
        [TestCase(14)]
        [TestCase(7)]
        [TestCase(1)]
        public void Add_WorksCorrectly_WhenCountIsLessThan16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            expectedDatabase.Add(new Person(200, "Ivan" + 200));

            int expected = people.Length + 1;
            int actual = expectedDatabase.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(16)]
        public void Add_Throws_InvalidOperationException_WhenCountIs16(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.Add(new Person(200, "Ivan" + 200)));

        }


        [Test]
        [TestCase(16)]
        [TestCase(14)]
        [TestCase(11)]
        [TestCase(7)]
        public void Add_Throws_InvalidOperationException_UserNameExists(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Person newExistingPerson = new Person(222, "Ivan" + 5);

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.Add(newExistingPerson));

        }

        [Test]
        [TestCase(16)]
        [TestCase(14)]
        [TestCase(11)]
        [TestCase(7)]
        public void Add_Throws_InvalidOperationException_IdExists(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Person newExistingPerson = new Person(5, "Ivan" + 222);

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.Add(newExistingPerson));

        }

        [Test]
        [TestCase(1)]
        public void Remove_Throws_InvalidOperationException_CountIs0(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            expectedDatabase.Remove();

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.Remove());
        }


        [Test]
        [TestCase(3)]
        [TestCase(15)]
        [TestCase(13)]
        [TestCase(11)]
        [TestCase(16)]
        public void Remove_Works_Correctly(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            expectedDatabase.Remove();
            expectedDatabase.Remove();
            expectedDatabase.Remove();

            int expected = people.Length - 3;
            int actual = expectedDatabase.Count;

            Assert.AreEqual(expected, actual);
            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.FindById(people.Length - 2));
            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.FindByUsername("Ivan" + (people.Length - 2)));
        }


        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindByUserName_Throws_InvalidOperationException_NoUserWithSuchName(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.FindByUsername("Pesho"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindByUserName_Throws_ArgumentNullException_UserNameGivenIsNull(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Assert.Throws<ArgumentNullException>
                (() => expectedDatabase.FindByUsername(null));
        }



        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindById_Throws_InvalidOperationException_NoSuchID(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Assert.Throws<InvalidOperationException>
                (() => expectedDatabase.FindById(123456));
        }

        [Test]
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(14)]
        [TestCase(16)]
        [TestCase(8)]
        public void FindById_Throws_ArgumentOutOfRangeException_NegativeID(int count)
        {
            Person[] people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, "Ivan" + i);
            }

            Database expectedDatabase = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>
                (() => expectedDatabase.FindById(-3));
        }
    }
}