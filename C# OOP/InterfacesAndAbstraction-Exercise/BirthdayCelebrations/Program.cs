using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> livingGuests = new List<IBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] information = input.Split();
                if(information[0] == "Citizen")
                {
                    livingGuests.Add(new Citizen(information[4]));
                }
                else if(information[0] == "Pet")
                {
                    livingGuests.Add(new Pet(information[2]));
                }
            }

            int yearToCheck = int.Parse(Console.ReadLine());

            foreach(var guest in livingGuests)
            {
                guest.CheckBirthYear(yearToCheck);
            }
        }
    }
}
