﻿using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarReepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarReepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }

            this.cars.Add(car);

            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            IRacer racer;

            if (type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }

            this.racers.Add(racer);

            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOne.Username} cannot be found!");
            }

            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwo.Username} cannot be found!");
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var racers = this.racers.Models.
                OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username);

            foreach (var racer in racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
