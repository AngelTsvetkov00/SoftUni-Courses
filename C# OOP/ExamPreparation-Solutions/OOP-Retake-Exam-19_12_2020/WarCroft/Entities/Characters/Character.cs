using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;
		private double abilityPoints;
		private IBag bag;
		private bool isAlive = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			Name = name;
			BaseHealth = health;
			Health = health;
			BaseArmor = armor;
			Armor = armor;
			AbilityPoints = abilityPoints;
			this.bag = bag;
        }

		public bool IsAlive 
		{
			get => isAlive;
			set => isAlive = value;
		}

        public string Name 
		{
			get => name;
			set
            {
				if(string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

				name = value;
            }
		}

        public double BaseHealth 
		{ 
			get => baseHealth; 
			set => baseHealth = value;
		}

        public double Health 
		{ 
			get => health;
			set
            {
				health = value;

				if (health < 0)
				{
					health = 0;
				}
				else if (health > BaseHealth)
				{
					health = BaseHealth;
				}
			}
		}

        public double BaseArmor { get => baseArmor; set => baseArmor = value; }

        public double Armor 
		{ 
			get => armor;
			set
			{
				armor = value;
				
				if (armor < 0)
				{
					armor = 0;
				}
			}
		}

        public double AbilityPoints { get => abilityPoints; set => abilityPoints = value; }

        public IBag Bag { get => bag; }

        public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
        {
			EnsureAlive();
			if(hitPoints <= Armor)
            {
				Armor -= hitPoints;
            }
			else if(hitPoints > armor)
            {
				var pointsLeft = hitPoints - Armor;
				Armor -= hitPoints;
				Health -= pointsLeft;
            }

			if(Health == 0)
            {
				isAlive = false;
            }
        }

		public void UseItem(Item item)
        {
			EnsureAlive();
			item.AffectCharacter(this);
        }

        public override string ToString()
        {
			string status = IsAlive ? "Alive" : "Dead";
			return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {status}";
		}
    }
}