using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICheckable
    {
        private string _name;
        private int _age;
        private string _id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get => _name; private set => _name = value; }
        
        public int Age { get => _age; private set => _age = value; }
        
        public string Id { get => _id; private set => _id = value; }
        
        public void CheckID(string checker)
        {
            if (this.Id.EndsWith(checker))
            {
                Console.WriteLine(this.Id);
            }
        }
    }
}
