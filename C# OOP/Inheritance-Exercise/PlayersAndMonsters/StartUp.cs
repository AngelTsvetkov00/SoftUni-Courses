using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero1 = new Hero("Zeus", 420);
            Elf elf1 = new Elf("Tinkerbell", 13);
            Console.WriteLine(hero1);
            Console.WriteLine(elf1);
        }
    }
}