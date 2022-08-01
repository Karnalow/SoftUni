using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameLength = 5;
        private const int MinLaps = 1;

        private string name;
        private int laps;

        private readonly IDictionary<string, IDriver> driversByName;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            driversByName = new Dictionary<string, IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameLength));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.driversByName.Values.ToList();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }
            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (this.driversByName.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.driversByName.Add(driver.Name, driver);
        }
    }
}
