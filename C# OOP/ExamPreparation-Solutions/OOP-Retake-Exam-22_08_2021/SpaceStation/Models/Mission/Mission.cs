using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (planet.Items.Count > 0)
            {
                var astronaut = astronauts.FirstOrDefault(x => x.Oxygen > 0);
                if (astronaut == null)
                {
                    break;
                }
                else
                {
                    while (astronaut.Oxygen > 0)
                    {
                        var planetItem = planet.Items.FirstOrDefault();
                        if (planetItem != null)
                        {
                            astronaut.Bag.Items.Add(planetItem);
                            planet.Items.Remove(planetItem);
                            astronaut.Breath();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
