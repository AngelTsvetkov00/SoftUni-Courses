using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace FoodShortage
{
    public class Citizen : ICheckable, IBirthable, IBuyer
    {
        private string _name;
        private int _age;
        private string _id;
        private string _birthdate;
        private int _food;

        public Citizen() { }

        public Citizen(string birthdate)
        {
            this.Birthdate = birthdate;
        }

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get => _name; private set => _name = value; }
        
        public int Age { get => _age; private set => _age = value; }
        
        public string Id { get => _id; private set => _id = value; }
        
        public string Birthdate { get => _birthdate; private set => _birthdate = value; }
        
        public int Food { get => _food; set => _food = value; }

        public void BuyFood()
        {
            this.Food += 10;
        }

        public void CheckBirthYear(int yearToCheck)
        {
            if (this.Birthdate.EndsWith(yearToCheck.ToString()))
            {
                Console.WriteLine(this.Birthdate);
            }
        }

        public void CheckID(string checker)
        {
            if (this.Id.EndsWith(checker))
            {
                Console.WriteLine(this.Id);
            }
        }
        
    }
}
