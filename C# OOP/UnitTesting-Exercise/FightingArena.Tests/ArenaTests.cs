
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_ShouldCreateAnEmptyList()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void IReadOnlyCollectionOfWarriors_ShouldReturnACopiedArena()
        {
            var copiedArena = arena.Warriors;

            CollectionAssert.AreEqual(copiedArena, arena.Warriors);
        }

        [Test]
        public void Enroll_ShouldThrowExceptionWhenNameExists()
        {
            arena.Enroll(new Warrior("Name", 10, 50));

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Name", 11, 51)));
        }

        [Test]
        public void Enroll_ShouldAddNewWarriorToArena()
        {
            arena.Enroll(new Warrior("Name", 10, 50));

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, arena.Count);
        }

        [Test]
        public void Fight_ShouldThrowExceptionIfWarriorNameInvalid()
        {
            var warriorPencho = new Warrior("Pencho", 40, 80);
            var warriorAnton = new Warrior("Anton", 41, 81);
            arena.Enroll(warriorPencho);
            arena.Enroll(warriorAnton);
            
            string attackerName = "Gencho";
            string attackerName2 = "Spiridon";

            Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorPencho.Name, attackerName));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorAnton.Name, attackerName2));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, attackerName2));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, warriorPencho.Name));
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, warriorAnton.Name));
        }

        [Test]
        public void Fight_ShouldDecreaseWarriorsHp()
        {
            var attacker = new Warrior("Niki", 51, 99);
            var defender = new Warrior("Mitko", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);
            var expectedHp = 49;

            Assert.AreEqual(expectedHp, defender.HP);
            Assert.AreEqual(expectedHp, attacker.HP);
        }

        [Test]
        public void Fight_ShouldThrowExceptionIfWarriorNotEnrolled()
        {
            var attacker = new Warrior("Niki", 51, 99);
            var defender = new Warrior("Mitko", 50, 100);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
        }
    }
}
