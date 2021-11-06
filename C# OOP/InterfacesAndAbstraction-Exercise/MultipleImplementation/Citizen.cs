using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private string _name;
        private int _age;
        private string _id;
        private string _birthdate;

        public Citizen(string name,int age,string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name 
        { 
            get => _name; 
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public string Id
        { 
            get => _id;
            set => _id = value; 
        }

        public string Birthdate 
        {
            get => _birthdate;
            set => _birthdate = value;
        }
    }
}
