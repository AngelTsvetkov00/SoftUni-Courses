using CarRacing.Core.Contracts;
using CarRacing.Models;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private IRepository<ICar> cars = new CarRepository();
        private IRepository<IRacer> racers = new RacerRepository();
        private IMap map = new Map();

        
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if(type !="SuperCar" && type !="TunedCar")
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            if(type == "SuperCar")
            {
                cars.Add(new SuperCar(make, model, VIN, horsePower));
            }
            else
            {
                cars.Add(new TunedCar(make, model, VIN, horsePower));
            }

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if(!cars.Models.Any(x => x.VIN == carVIN))
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if(type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            var car = cars.Models.FirstOrDefault(x => x.VIN == carVIN);

            if (type == "ProfessionalRacer")
            {
                racers.Add(new ProfessionalRacer(username, car));
            }
            else
            {
                racers.Add(new StreetRacer(username,car));
            }

            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            var racerTwo = racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            if(racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var racer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
