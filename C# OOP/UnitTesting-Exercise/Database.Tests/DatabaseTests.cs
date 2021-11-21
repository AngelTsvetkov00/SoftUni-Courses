using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        
        [SetUp]
        public void Setup()
        {
            database = new Database();  
        }

        [Test]
        public void Ctor_ShouldThrowExceptionWhenDatabaseCountIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 ,17));
        }

        [Test]
        public void Ctor_ShouldAddValidItemsToDatabase()
        {
            var elements = new int[] { 1, 2, 3 };
            database = new Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_ShouldIncrementCount()
        {
            var n = 5;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_ShouldThrowExceptionWhenDatabaseHasNoMorePlaces()
        {
            var n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Remove_ShouldDecreaseDatabaseCapacity()
        {
            int n = 16;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            var expectedCount = 15;

            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void Remove_ShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_ShouldRemoveLastElementFromDatabase()
        {
            int n = 10;
            var lastElement = 10;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            var elements = database.Fetch();

            Assert.IsFalse(elements.Contains(lastElement));          
        }

        [Test]
        public void Fetch_ShouldReturnAnArrayWithSameCount()
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            var copiedElements = database.Fetch();

            Assert.AreEqual(copiedElements.Length, database.Count);
        }

    }
}