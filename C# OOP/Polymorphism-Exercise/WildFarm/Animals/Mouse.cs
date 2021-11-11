using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            string animalType = this.GetType().Name;
            string foodType = food.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                this.Weight += food.Quantity * 0.10;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{animalType} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Mouse [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
