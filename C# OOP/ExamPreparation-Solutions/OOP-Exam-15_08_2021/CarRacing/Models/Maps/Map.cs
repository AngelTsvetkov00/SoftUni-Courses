using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwo.IsAvailable() == false)
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            string racerOneBehavior = racerOne.RacingBehavior;
            string racerTwoBehavior = racerTwo.RacingBehavior;

            if(racerOneBehavior == "strict")
            {
                racerOneChanceOfWinning *= 1.2;
            }
            else if(racerOneBehavior == "aggressive")
            {
                racerOneChanceOfWinning *= 1.1; 
            }

            if (racerTwoBehavior == "strict")
            {
                racerTwoChanceOfWinning *= 1.2;
            }
            else if (racerTwoBehavior == "aggressive")
            {
                racerTwoChanceOfWinning *= 1.1;
            }


            string winnerName;

            if(racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                winnerName = racerOne.Username;
            }
            else
            {
                winnerName = racerTwo.Username;
            }

            racerOne.Race();
            racerTwo.Race();

            return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerName);
        }
    }
}
