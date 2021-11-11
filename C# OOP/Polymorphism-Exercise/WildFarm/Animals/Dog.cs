using System;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(Food food)
        {
            string animalType = this.GetType().Name;
            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                this.Weight += food.Quantity * 0.40;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{animalType} does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Dog [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
