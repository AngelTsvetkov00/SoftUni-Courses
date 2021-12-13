using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private ICollection<IEquipment> equipment = new List<IEquipment>();
        private ICollection<IAthlete> athletes = new List<IAthlete>();

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }

        public double EquipmentWeight => equipment.Sum(x=> x.Weight);

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            else
            {
                athletes.Add(athlete);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach(var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            string athletesInGym = athletes.Count > 0 ? $"{String.Join(", ", this.athletes.Select(x=> x.FullName))}" : "No athletes";
            sb.AppendLine($"Athletes: {athletesInGym}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);
    }
}
