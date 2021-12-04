using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party = new List<Character>();
		private List<Item> pool = new List<Item>();
		public WarController()
		{
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
			Character hero;

			if(characterType != "Warrior" && characterType != "Priest")
            {
				throw new ArgumentException(ExceptionMessages.InvalidCharacterType);
            }
			else if (characterType == "Warrior")
            {
				hero = new Warrior(name);
				party.Add(hero);
			}
			else if (characterType == "Priest")
			{
				hero = new Priest(name);
				party.Add(hero);
			}

			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item;

			if (itemName != "HealthPotion" && itemName != "FirePotion")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem,itemName));
			}
			else if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
				pool.Add(item);
			}
			else if (itemName == "FirePotion")
			{
				item = new FirePotion();
				pool.Add(item);
			}

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			if(!party.Any(x=> x.Name == characterName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

			if(pool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			var character = party.FirstOrDefault(x => x.Name == characterName);
			var itemName = pool.Last().GetType().Name;

			character.Bag.AddItem(pool.Last());
			pool.Remove(pool.Last());

			return string.Format(SuccessMessages.PickUpItem, characterName, itemName);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			if (!party.Any(x => x.Name == characterName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			var character = party.FirstOrDefault(x => x.Name == characterName);
			var item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);

		}

		public string GetStats()
		{
			List<Character> ordered = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList();
			var sb = new StringBuilder();
			
			foreach(var hero in ordered)
            {
				sb.AppendLine(hero.ToString());
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			if (!party.Any(x => x.Name == attackerName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}

			if (!party.Any(x => x.Name == receiverName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			var attacker = party.FirstOrDefault(x => x.Name == attackerName);
			
			if (attacker.GetType().Name == "Priest")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}

			var attackingChar = (Warrior)party.FirstOrDefault(x => x.Name == attackerName);
			var receiver = party.FirstOrDefault(x => x.Name == receiverName);

			attackingChar.Attack(receiver);

			var sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, 
				receiverName, attackingChar.AbilityPoints, 
				receiverName, receiver.Health, receiver.BaseHealth, 
				receiver.Armor, receiver.BaseArmor));
			
			if(!receiver.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			if (!party.Any(x => x.Name == healerName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}

			if (!party.Any(x => x.Name == healingReceiverName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			var healer = party.FirstOrDefault(x => x.Name == healerName);

			if (healer.GetType().Name == "Warrior")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			Priest healerChar = (Priest)party.FirstOrDefault(x => x.Name == healerName);
			var receiver = party.FirstOrDefault(x => x.Name == healingReceiverName);

			healerChar.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healerChar.AbilityPoints,
				healingReceiverName, receiver.Health);
		}
	}
}
