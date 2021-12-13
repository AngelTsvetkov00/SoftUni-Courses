using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core.Contracts
{
    public class Controller : IController
    {
        private EquipmentRepository equipment = new EquipmentRepository();
        private ICollection<IGym> gyms = new List<IGym>();


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (gym.GetType().Name == "BoxingGym" && athleteType !="Boxer")
            {
                return OutputMessages.InappropriateGym;
            }

            if (gym.GetType().Name == "WeightliftingGym" && athleteType != "Weightlifter")
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete;
            if(athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                gym.AddAthlete(athlete);
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            else if (equipmentType == "BoxingGloves")
            {
                var newestEquipment = new BoxingGloves();
                equipment.Add(newestEquipment);
                return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
            else
            {
                var newestEquipment = new Kettlebell();
                equipment.Add(newestEquipment);
                return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            }
        }

        public string AddGym(string gymType, string gymName)
        {
            if(gymType != "BoxingGym" && gymType !="WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            else if(gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
                return string.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
            else
            {
                gyms.Add(new WeightliftingGym(gymName));
                return string.Format(OutputMessages.SuccessfullyAdded, gymType);
            }
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            double value = gym.EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{value:f2}");
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            var equipmentToAdd = equipment.FindByType(equipmentType);

            if(equipmentToAdd == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipmentToAdd);
            equipment.Remove(equipmentToAdd);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach(var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);

            foreach(var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
