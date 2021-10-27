using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }

        private string _name;
        public string Name { get => _name; set => _name = value; }



    }
}
