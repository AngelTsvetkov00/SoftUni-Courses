using System;
using System.Collections.Generic;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICheckable> inhabitants = new List<ICheckable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] information = input.Split();
                
                if(information.Length == 2)
                {
                    inhabitants.Add(new Robot(information[0], information[1]));
                }
                else if(information.Length == 3)
                {
                    inhabitants.Add(new Citizen(information[0],int.Parse(information[1]),information[2]));
                }
            }

            string digitsToCheck = Console.ReadLine();

            foreach(var inhabitant in inhabitants)
            {
                inhabitant.CheckID(digitsToCheck);
            }
        }
    }
}
