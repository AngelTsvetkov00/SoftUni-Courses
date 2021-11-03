using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private List<Topping> _toppings;
        private Dough _dough;
        private double _calories;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.PizzaDough = dough;
            Toppings = new List<Topping>();
        }

        public string Name 
        {
            get => _name;
            private set
            {
                if(value == null || value.Trim()=="" || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                _name = value;
            }
        }

        public List<Topping> Toppings
        {
            get => _toppings;
            set => _toppings = value;
        }

        public Dough PizzaDough 
        { 
            get => _dough;
            set => _dough = value; 
        }

        public double TotalCalories
        {
            get
            {
                foreach(var topping in _toppings)
                {
                    _calories += topping.Calories;
                }

                _calories += this.PizzaDough.Calories;

                return Math.Round(_calories, 2);
            }
        }

        public int ToppingsCount => Toppings.Count;

        public void AddTopping(Topping topping)
        {
            if(Toppings.Count >= 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            Toppings.Add(topping);
        }
    }
}
