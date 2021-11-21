using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_ShouldAddItemsToDatabase()
        {
            var person = new Person(1233424, "BAHKO1");
            var person2 = new Person(11111111, "BAHKO");

            database.Add(person);
            database.Add(person2);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void Ctor_ShouldAddValidItemsToDatabase()
        {
            var person = new Person(1233424, "BAHKO1");
            var person2 = new Person(11111111, "BAHKO");
            var elements = new Person[] {person,person2};
            database = new ExtendedDatabase(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Ctor_ShouldThrowExceptionWhenDatabaseCountIsExceeded()
        {
            var newDatabase = new List<Person>();
            for (int i = 0; i < 17; i++)
            {
                newDatabase.Add(new Person(i, i.ToString()));
            }

            var arrayToTest = newDatabase.ToArray();
            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(arrayToTest));
        }

        [Test]
        public void Add_ShouldThrowExceptionForPeopleWithSameUsername()
        {
            var person = new Person(1233424, "BAHKO1");
            database.Add(person);

            var person2 = new Person(999999, "BAHKO1");

            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        public void Add_ShouldThrowExceptionForPeopleWithSameId()
        {
            var person = new Person(1233424, "BAHKO1");
            database.Add(person);

            var person2 = new Person(1233424, "CTAM0");

            Assert.Throws<InvalidOperationException>(() => database.Add(person2));
        }

        [Test]
        public void Add_ShouldThrowExceptionWhenDatabaseCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17,"17")));
        }

        [Test]
        public void Remove_ShouldThrowExceptionIfCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_ShouldDecrementCount()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            database.Remove();

            var expectedCount = 14;

            Assert.AreEqual(database.Count,expectedCount);

        }

        [Test]
        public void FindByUsername_ShouldThrowExceptionIfUsernameIsNotFound()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Person personToFind;
            Assert.Throws<InvalidOperationException>(() => personToFind = database.FindByUsername("17"));
        }

        [Test]
        public void FindByUsername_ShouldThrowExceptionIfUsernameIsNull()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Person personToFind;

            Assert.Throws<ArgumentNullException>(() => personToFind = database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => personToFind = database.FindByUsername(string.Empty));
        }

        [Test]
        public void FindByUsername_ShouldReturnPersonIfFound()
        {
            var person = new Person(0, "BAHKO1");

            database.Add(person);
          
            var expectedPerson = database.FindByUsername("BAHKO1");

            Assert.AreEqual(person, expectedPerson);
        }

        [Test]
        public void Usernames_ShouldBeCaseSensitive()
        {
            database.Add(new Person(0, "BaHKo1"));

            var person = database.FindById(0);
            var differentPerson = new Person(0, "BAHKO1");

            Assert.AreNotEqual(person, differentPerson.UserName);
        }

        [Test]
        public void FindById_ShouldReturnPersonIfFound()
        {
            var person = new Person(0, "BAHKO1");

            database.Add(person);

            var expectedPerson = database.FindById(0);

            Assert.AreEqual(person, expectedPerson);
        }

        [Test]
        public void FindById_ShouldThrowExceptionIfIdIsNotFound()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Person personToFind;
            Assert.Throws<InvalidOperationException>(() => personToFind = database.FindById(17));
        }

        [Test]
        public void FindById_ShouldThrowExceptionIfIdIsNegative()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Person personToFind;
            Assert.Throws<ArgumentOutOfRangeException>(() => personToFind = database.FindById(-17));
        }
    }
}