using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models = new List<IPlanet>();

        public IReadOnlyCollection<IPlanet> Models
        {
            get => this.models.AsReadOnly();
        }

        public void Add(IPlanet model)
        {
            if (!models.Any(x => x.Name == model.Name))
            {
                models.Add(model);
            }
        }

        public IPlanet FindByName(string name)
        {
            return models.First(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }
    }
}
