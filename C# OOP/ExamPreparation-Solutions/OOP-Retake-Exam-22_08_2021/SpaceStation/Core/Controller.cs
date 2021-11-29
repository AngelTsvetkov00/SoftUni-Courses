using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int planetCount;
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planets = new PlanetRepository();

        public Controller()
        {

        }

        public string AddAstronaut(string type, string astronautName)
        {
            Astronaut astronaut;
            switch(type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);

                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);

                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);

                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            
            foreach(string s in items)
            {
                planet.Items.Add(s);
            }

            planets.Add(planet);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planets.FindByName(planetName);

            List<IAstronaut> astronautsWithEnoughOxygen = astronauts.Models.ToList();
            astronautsWithEnoughOxygen.RemoveAll(x => x.Oxygen < 60);

            if(astronautsWithEnoughOxygen.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();

            mission.Explore(planet, astronautsWithEnoughOxygen);
            planetCount++;
            int deadAstronauts = astronautsWithEnoughOxygen.Count(a => a.Oxygen == 0);

            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{planetCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach(var astronaut in this.astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
           if(this.astronauts.FindByName(astronautName) == null)
           {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,astronautName));
           }

            var astronaut = astronauts.FindByName(astronautName);
            astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
    }
}
