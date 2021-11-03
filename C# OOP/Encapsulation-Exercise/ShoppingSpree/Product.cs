using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string _name;
        private double _cost;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name 
        { 
            get => _name; 
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public double Cost 
        { 
            get => _cost; 
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    _cost = value;
                }
            }
        }

        public override string ToString() => this.Name;
    }
}
