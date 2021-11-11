using System;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            System.Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            string animalType = this.GetType().Name;
            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                this.Weight += food.Quantity * 1.00;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{animalType} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Tiger [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
