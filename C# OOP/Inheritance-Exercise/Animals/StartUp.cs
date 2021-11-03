using System.Collections.Generic;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = "";

            while((command=Console.ReadLine()).Trim(' ') != "Beast!")
            {
                string animalType = command.Trim(' ');
                string[] animalInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInput[0];
                int age = int.Parse(animalInput[1]);
                string gender = animalInput[2];
                Animal animal;

                if(age < 0 || name == null || (gender != "Male" && gender !="Female") || gender==null)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if(animalType=="Dog")
                {
                    animal = new Dog(name, age, gender);
                }
                else if (animalType == "Cat")
                {
                    animal = new Cat(name, age, gender);
                }
                else if(animalType == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }
                else if (animalType == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else if (animalType == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                animals.Add(animal);
            }

            Console.WriteLine(string.Join(Environment.NewLine, animals));

        }
    }
}
