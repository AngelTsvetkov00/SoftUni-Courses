using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string _name;
        private int _age;
        private string _group;
        private int _food;

        public Rebel() { }

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get => _name; private set => _name = value; }
        
        public int Age { get => _age; private set => _age = value; }

        public string Group { get => _group; private set => _group = value; }
        
        public int Food { get => _food; set => _food = value; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
