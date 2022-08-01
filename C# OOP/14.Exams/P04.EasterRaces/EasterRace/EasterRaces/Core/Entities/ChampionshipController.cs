using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinRaceParticipants = 3;

        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);
            ICar car = this.carRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            this.carRepository.Add(car);

            type = type + "Car";

            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return String.Format(OutputMessages.RaceCreated , name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < MinRaceParticipants)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MinRaceParticipants));
            }

            IDriver[] winners = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            string driverOnFirstPosition = winners[0].Name;
            string driverOnSecondPosition = winners[1].Name;
            string driverOnThirdPosition = winners[2].Name;

            this.raceRepository.Remove(race);

            return String.Format(OutputMessages.DriverFirstPosition, driverOnFirstPosition, race.Name) +
                Environment.NewLine +
                String.Format(OutputMessages.DriverSecondPosition, driverOnSecondPosition, race.Name) +
                Environment.NewLine +
                String.Format(OutputMessages.DriverThirdPosition, driverOnThirdPosition, race.Name);
        }
    }
}
