using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {           
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string[] doughInfo = Console.ReadLine().Split();

                string pizzaName = pizzaInfo[1];
                string doughFlour = doughInfo[1];
                string doughBakeTech = doughInfo[2];
                var doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughFlour, doughBakeTech, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string command = "";
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command.Split();
                    string toppingType = toppingInfo[1];
                    int toppingWeight = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
