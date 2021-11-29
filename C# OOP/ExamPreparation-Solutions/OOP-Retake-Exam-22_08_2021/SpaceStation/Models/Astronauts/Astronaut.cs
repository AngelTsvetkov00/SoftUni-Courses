using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Bags;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private bool canBreath;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();       
        }


        public string Name 
        {
            get => this.name;
            
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen 
        {
            get => this.oxygen;

            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get => this.canBreath;

            private set
            {
                this.canBreath = value;
            }
        }

        public IBag Bag
        {
            get => this.bag;
            private set 
            {
                this.bag = value;
            }
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine($"{this.Bag.ToString()}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
