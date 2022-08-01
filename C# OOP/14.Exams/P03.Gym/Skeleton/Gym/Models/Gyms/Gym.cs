using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight
        {
            get => this.Equipment.Sum(w => w.Weight);
        }

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity > this.Athletes.Count)
            {
                this.Athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");

            if (this.Athletes.Count > 0)
            {
                List<string> athletes = new List<string>();

                foreach (var athlete in this.Athletes)
                {
                    athletes.Add(athlete.FullName);
                }

                sb.AppendLine(string.Join(", ", athletes));
            }
            else
            {
                sb.AppendLine("No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            if (this.Athletes.Contains(athlete))
            {
                this.Athletes.Remove(athlete);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
