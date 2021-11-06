using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var info = Console.ReadLine().Split();

                if (info.Length == 4)
                {
                    buyers.Add(new Citizen(info[0], int.Parse(info[1]), info[2], info[3]));
                }
                else if (info.Length == 3)
                {
                    buyers.Add(new Rebel(info[0], int.Parse(info[1]), info[2]));
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
