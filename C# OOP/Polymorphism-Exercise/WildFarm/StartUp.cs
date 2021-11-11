using System;
using System.Collections.Generic;
using WildFarm.Animals;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            
            string input = "";
            int counter = -1;

            while((input = Console.ReadLine()) != "End")
            {
                counter++;
                bool isEven = counter % 2 == 0;
                string[] inputSplit = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if(isEven)
                {
                    var animalType = inputSplit[0];
                    var animalName = inputSplit[1];
                    var animalWeight = double.Parse(inputSplit[2]);

                    switch (animalType)
                    {
                        case "Cat":
                            animals.Add(new Cat(animalName, animalWeight, inputSplit[3], inputSplit[4]));
                            break;
                        case "Tiger":
                            animals.Add(new Tiger(animalName, animalWeight, inputSplit[3], inputSplit[4]));
                            break;
                        case "Hen":
                            animals.Add(new Hen(animalName, animalWeight, double.Parse(inputSplit[3])));
                            break;
                        case "Owl":
                            animals.Add(new Owl(animalName, animalWeight, double.Parse(inputSplit[3])));
                            break;
                        case "Mouse":
                            animals.Add(new Mouse(animalName, animalWeight, inputSplit[3]));
                            break;
                        case "Dog":
                            animals.Add(new Dog(animalName, animalWeight, inputSplit[3]));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    var foodType = inputSplit[0];
                    var foodQuantity = int.Parse(inputSplit[1]);
                    Food food;
                    Animal lastAnimal = animals[animals.Count - 1];

                    switch (foodType)
                    {
                        case "Vegetable":
                            food = new Vegetable(foodQuantity);
                            lastAnimal.Eat(food);
                            break;
                        case "Fruit":
                            food = new Fruit(foodQuantity);
                            lastAnimal.Eat(food);
                            break;
                        case "Meat":
                            food = new Meat(foodQuantity);
                            lastAnimal.Eat(food);
                            break;
                        case "Seeds":
                            food = new Seeds(foodQuantity);
                            lastAnimal.Eat(food);
                            break;
                        default:
                            break;
                    }                    
                }
            }

            foreach(var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
