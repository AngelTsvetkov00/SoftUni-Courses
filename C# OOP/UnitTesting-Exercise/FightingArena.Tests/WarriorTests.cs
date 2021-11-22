
using NUnit.Framework;
using System;


namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private const int MIN_ATTACK_HP = 30;
        
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Name", 50, 100);
        }

        [Test]
        public void Name_ShouldThrowExceptionForNullName()
        {
            string name = null;
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Name_ShouldThrowExceptionForEmptyName()
        {
            string name = string.Empty;
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Name_ShouldThrowExceptionForWhitespaceName()
        {
            string name = "         ";
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>{
                warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Damage_ShouldThrowExceptionIfZero()
        {
            string name = "Pencho";
            int damage = 0;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Damage_ShouldThrowExceptionIfNegative()
        {
            string name = "Gencho";
            int damage = -1;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Hp_ShouldThrowExceptionIfNegative()
        {
            string name = "BAHKO1";
            int damage = 50;
            int HP = -100;

            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, HP);
            });
        }
        [Test]
        public void Ctor_ShouldCreateValidObject()
        {
            string name = "Name";
            int damage = 50;
            int hp = 100;
            var testWarrior = new Warrior(name, damage, hp);

            Assert.AreEqual(testWarrior.Name, warrior.Name);
            Assert.AreEqual(testWarrior.Damage, warrior.Damage);
            Assert.AreEqual(testWarrior.HP, warrior.HP);
        }
        
        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void Attack_ShouldThrowExceptionWhenAttackerHpIsLowerOrEqualThanRequired(int attackerHP)
        {
            Warrior attacker = new Warrior("Joro", 10, attackerHP);
            Warrior defender = new Warrior("Pencho", 10, 40);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void Attack_ShouldThrowExceptionWhenDefenderHpIsLowerOrEqualThanRequired(int defenderHP)
        {
            Warrior attacker = new Warrior("Joro", 10, 50);
            Warrior defender = new Warrior("Pencho", 10, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrowExceptionWhenAttakerHpIsLowerThanDefenderDamage()
        {
            var lowHpAttacker = new Warrior("Name", 50, 40);

            var bigDamageDefender = new Warrior("Pencho", 41, 100);

            Assert.Throws<InvalidOperationException>(() => lowHpAttacker.Attack(bigDamageDefender));
        }

        [Test]
        public void Attack_ShouldDecreaseAttackerHP()
        {
            var attacker = new Warrior("Name", 50, 100);

            var defender = new Warrior("Pencho", 50, 100);

            attacker.Attack(defender);

            var expectedAttackerHp = 50;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
        }

        [Test]
        public void Attack_ShouldDecreaseDefenderHP()
        {
            var attacker = new Warrior("Name", 50, 100);

            var defender = new Warrior("Pencho", 50, 100);

            attacker.Attack(defender);

            var expectedDefenderHp = 50;

            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void Attack_ShouldDecreaseDefenderHPToAMinimumOfZero()
        {
            var attacker = new Warrior("Name", 50, 100);

            var defender = new Warrior("Pencho", 50, 41);

            attacker.Attack(defender);

            var expectedDefenderHp = 0;

            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void Attack_ShouldDecreaseAttackerHPToZero()
        {
            var attacker = new Warrior("Name", 50, 50);

            var defender = new Warrior("Pencho", 50, 31);

            attacker.Attack(defender);

            var expectedAttackerHp = 0;

            Assert.AreEqual(expectedAttackerHp, defender.HP);
        }

       
    }
}