using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata;

namespace BirthdayCelebrations
{
    public class Pet : IBirthable
    {
        private string _name;
        private string _birthdate;

        public Pet(string birthdate)
        {
            this.Birthdate = birthdate;
        }

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get => _name; private set => _name = value; }

        public string Birthdate { get => _birthdate; private set => _birthdate = value; }

        public void CheckBirthYear(int yearToCheck)
        {
            if(this.Birthdate.EndsWith(yearToCheck.ToString()))
            {
                Console.WriteLine(this.Birthdate);
            }
        }
    }
}
