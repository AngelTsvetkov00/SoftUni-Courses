using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        public Aquarium(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.fish.Count == capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach(var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            string fishes = this.fish.Count > 0 ? $"Fish: {(string.Join(", ", this.Fish.Select(x => x.Name)))}" : "Fish: none";
            sb.AppendLine(fishes);
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);
    }
}
