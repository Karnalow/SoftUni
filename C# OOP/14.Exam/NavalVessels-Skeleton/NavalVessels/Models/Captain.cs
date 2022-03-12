using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;

        public Captain(string fullName)
        {
            this.FullName = fullName;

            this.Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }

                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            set => combatExperience = 0;
        }

        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {this.Vessels.Count} vessels.");

            if (this.Vessels.Count > 0)
            {
                foreach (var vessel in this.Vessels)
                {
                    sb.AppendLine($"- {vessel.Name}");
                    sb.AppendLine($"*Type: {vessel.GetType().Name}");
                    sb.AppendLine($"*Armor thickness: {vessel.ArmorThickness}");
                    sb.AppendLine($"*Main weapon caliber: {vessel.MainWeaponCaliber}");
                    sb.AppendLine($"*Speed: {vessel.Speed} knots");
                    sb.AppendLine($"*Targets: None/{vessel.Targets}");
                    sb.AppendLine("*Sonar/Submerge mode: ON/OFF");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
