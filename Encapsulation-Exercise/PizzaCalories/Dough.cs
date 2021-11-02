using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string _flourType;
        private string _bakingTech;
        private double _weight;
        private double _modifier = 1;

        public Dough(string flourType, string bakingTech, double weight)
        {
            FlourType = flourType;
            BakingTech = bakingTech;
            Weight = weight;
        }

        public string FlourType
        {
            get => _flourType;
            private set
            {
                if(!value.Equals("White", StringComparison.OrdinalIgnoreCase) &&
                   !value.Equals("Wholegrain", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Invalid type of dough.");
                }

                _flourType = value;
            }
        }
        
        public string BakingTech 
        { 
            get => _bakingTech;
            private set 
            {
                if (!value.Equals("Chewy", StringComparison.OrdinalIgnoreCase) &&
                   !value.Equals("Crispy", StringComparison.OrdinalIgnoreCase) &&
                   !value.Equals("Homemade", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Invalid type of dough.");
                }

                _bakingTech = value;
            }
        }
        
        public double Weight 
        { 
            get => _weight; 
            private set 
            {
                if(value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                _weight = value;
            } 
        }

        public double Modifier 
        {
            get
            {
                if (this.FlourType.Equals("White", StringComparison.OrdinalIgnoreCase))
                {
                    _modifier *= 1.5;
                }
                else
                {
                    _modifier *= 1.0;
                }

                if (this.BakingTech.Equals("Crispy", StringComparison.OrdinalIgnoreCase))
                {
                    _modifier *= 0.9;
                }
                else if (this.BakingTech.Equals("Chewy", StringComparison.OrdinalIgnoreCase))
                {
                    _modifier *= 1.1;
                }
                else
                {
                    _modifier *= 1.0;
                }

                return _modifier;
            }
        }

        public double Calories => Math.Round(this.Modifier * this.Weight * 2.00, 2);
    }
}
