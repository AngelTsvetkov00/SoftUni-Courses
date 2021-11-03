using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string _type;
        private double _weight;
        private double _modifier = 1;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type 
        { 
            get => _type; 
            private set
            {
                if(!value.Equals("Meat", StringComparison.OrdinalIgnoreCase) &&
                   !value.Equals("Veggies", StringComparison.OrdinalIgnoreCase) && 
                   !value.Equals("Cheese", StringComparison.OrdinalIgnoreCase) &&
                   !value.Equals("Sauce", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                _type = value;
            }
        }

        public double Weight 
        {
            get => _weight;
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                _weight = value;
            }
        }

        public double Modifier
        {
            get
            {
                switch(Type.ToLower())
                {
                    case "meat":
                        _modifier *= 1.2;
                        break;
                    case "veggies":
                        _modifier *= 0.8;
                        break;
                    case "cheese":
                        _modifier *= 1.1;
                        break;
                    case "sauce":
                        _modifier *= 0.9;
                        break;
                }

                return _modifier;
            }
        }

        public double Calories => Math.Round(2 * this.Modifier * this.Weight, 2);
    }
}
