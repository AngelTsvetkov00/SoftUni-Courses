using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        private string _name;
        private decimal _price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
    }
}
