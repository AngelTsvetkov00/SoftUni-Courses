using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string _name;
        private int _age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {Name}, Age: {Age}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
