using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public ICollection<string> items;
        
        public Backpack()
        {
            Items = new List<string>();
        }
        public ICollection<string> Items
        {
            get => items;
            private set
            {
                this.items = value;
            }
        }

        public override string ToString()
        {
            return this.Items.Count > 0 ? $"Bag items: {String.Join(", ", this.Items)}" : "Bag items: none";
        }
    }
}
