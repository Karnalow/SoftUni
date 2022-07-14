using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;

            participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            if (this.participants.Count < this.Capacity &&
                !this.participants.Contains(car) &&
                car.HorsePower <= this.MaxHorsePower)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            foreach (var participent in this.participants)
            {
                if (licensePlate == participent.LicensePlate)
                {
                    participants.Remove(participent);

                    return true;
                }
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
            => this.participants.Find(x => x.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar()
        {
            int powerfulCar = 0;

            foreach (var car in this.participants)
            {
                if (powerfulCar < car.HorsePower)
                {
                    powerfulCar = car.HorsePower;
                }
            }

            return this.participants.Find(x => x.HorsePower == powerfulCar);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in this.participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
