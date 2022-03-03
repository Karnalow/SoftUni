using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            IRacer winner;

            double firstRacerChance = racerOne.Car.HorsePower * racerOne.DrivingExperience;

            if (racerOne.RacingBehavior == "strict")
            {
                firstRacerChance *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                firstRacerChance *= 1.1;
            }

            double secondRacerChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            if (racerTwo.RacingBehavior == "strict")
            {
                secondRacerChance *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                secondRacerChance *= 1.1;
            }

            if (firstRacerChance > secondRacerChance)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}!" +
                    $" {winner.Username} is the winner!";
        }
    }
}
