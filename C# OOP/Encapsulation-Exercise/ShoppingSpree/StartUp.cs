using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var peopleInput = Console.ReadLine();
            var productsInput = Console.ReadLine();

            string[] peopleInfo = peopleInput.Split(new char[] { ';', '=' });
            string[] productsInfo = productsInput.Split(new char[] { ';', '=' });

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < peopleInfo.Length; i+=2)
                {
                    if (peopleInfo[i] != "")
                    {
                        string personName = peopleInfo[i];
                        double personMoney = double.Parse(peopleInfo[i + 1]);
                        Person person = new Person(personName, personMoney);
                        people.Add(person);
                    }
                }

                for (int i = 0; i < productsInfo.Length; i+=2)
                {
                    if (productsInfo[i] != "")
                    {
                        string productName = productsInfo[i];
                        double productCost = double.Parse(productsInfo[i + 1]);
                        Product product = new Product(productName, productCost);
                        products.Add(product);
                    }
                }            

                string command = "";

                while((command=Console.ReadLine()) != "END")
                {
                    string[] shoppingInfo = command.Split();
                    Person person = people.FirstOrDefault(x => x.Name == shoppingInfo[0]);
                    Product product = products.FirstOrDefault(p => p.Name == shoppingInfo[1]);

                    person.AddProduct(product);
                }

                foreach(var person in people)
                {
                    person.PrintProducts();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
