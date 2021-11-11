using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                BaseHero hero;
                
                switch(heroType)
                {
                    case "Druid":
                        hero = new Druid(heroName);
                        raidGroup.Add(hero);
                        break;
                    case "Warrior":
                        hero = new Warrior(heroName);
                        raidGroup.Add(hero);
                        break;
                    case "Rogue":
                        hero = new Rogue(heroName);
                        raidGroup.Add(hero);
                        break;
                    case "Paladin":
                        hero = new Paladin(heroName);
                        raidGroup.Add(hero);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        i--;
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach(var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if(raidGroup.Sum(x => x.Power) >= bossPower)
            {
                
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
