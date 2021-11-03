using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string _name;
        private double _money;
        private List<Product> _bagOfProducts;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (value == null || value.Trim(' ')=="")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public double Money 
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    _money = value;
                }
            }
        }

        public List<Product> BagOfProducts 
        {
            get => _bagOfProducts;
            private set => _bagOfProducts = value;
        }

        public void AddProduct(Product product)
        {
            if(this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }

        }

        public void PrintProducts()
        {
            if (BagOfProducts.Count > 0)
            {
                Console.WriteLine($"{this.Name} - {String.Join(", ", this.BagOfProducts)}");
            }
            else
            {
                Console.WriteLine($"{this.Name} - Nothing bought");
            }
        }


    }
}
