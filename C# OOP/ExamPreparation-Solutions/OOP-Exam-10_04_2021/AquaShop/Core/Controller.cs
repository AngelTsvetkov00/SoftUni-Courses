using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations = new DecorationRepository();
        private ICollection<IAquarium> aquariums = new List<IAquarium>();
        
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if(aquariumType == "FreshwaterAquarium")
            {
                var aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                var aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                var decoration = new Ornament();
                decorations.Add(decoration);
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else if (decorationType == "Plant")
            {
                var decoration = new Plant();
                decorations.Add(decoration);
                return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if(fishType !="FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var aquariumType = aquarium.GetType().Name.Remove(aquarium.GetType().Name.Length - 8);
            var fishWaterType = fishType.Remove(fishType.Length - 4);

            if(aquariumType != fishWaterType)
            {
                return OutputMessages.UnsuitableWater;
            }

            if(fishType == "SaltwaterFish")
            {
                aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
            }
            else
            {
                aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal value = 0;
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            value += aquarium.Fish.Sum(x => x.Price);
            value += aquarium.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{value:f2}");
        }

        public string FeedFish(string aquariumName)
        {
            int count = 0;
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.Models.FirstOrDefault(x => x.GetType().Name == decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
