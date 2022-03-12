using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core.Contracts
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            Captain captain = new Captain(selectedCaptainName);

            var captainFullName = this.captains.FirstOrDefault
                (x => x.FullName == captain.FullName);

            if (!this.captains.Contains(captainFullName))
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            var searchedVessel = this.vessels.FindByName(selectedVesselName);

            if (!this.vessels.Models.Contains(searchedVessel))
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (searchedVessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            else
            {
                captain.AddVessel(searchedVessel);

                return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = this.vessels.FindByName(attackingVesselName);
            var defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (!this.vessels.Models.Contains(attackingVessel))
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (!this.vessels.Models.Contains(defendingVessel))
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (!this.vessels.Models.Contains(defendingVessel))
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            Captain captain = new Captain(captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);

            var captainFullName = this.captains.FirstOrDefault
                (x => x.FullName == captain.FullName);

            if (!this.captains.Contains(captainFullName))
            {
                this.captains.Add(captain);

                return $"Captain {fullName} is hired.";
            }
            else
            {
                return $"Captain {fullName} is already hired.";
            }
        }

        public string ProduceVessel(string name,
            string vesselType,
            double mainWeaponCaliber,
            double speed)
        {
            Vessel vessel;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);

                if (!this.vessels.Models.Contains(vessel))
                {
                    this.vessels.Add(vessel);

                    return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
                }
                else
                {
                    return $"{vesselType} vessel {name} is already manufactured.";
                }
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);

                if (!this.vessels.Models.Contains(vessel))
                {
                    this.vessels.Add(vessel);

                    return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
                }
                else
                {
                    return $"{vesselType} vessel {name} is already manufactured.";
                }
            }
            else
            {
                return "Invalid vessel type.";
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var searchedVessel = this.vessels.FindByName(vesselName);

            if (this.vessels.Models.Contains(searchedVessel))
            {
                searchedVessel.RepairVessel();

                return $"Vessel {vesselName} was repaired.";
            }
            else
            {
                return $"Vessel {vesselName} could not be found.";
            }
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var searchedVessel = this.vessels.FindByName(vesselName);

            if (this.vessels.Models.Contains(searchedVessel) &&
                searchedVessel.GetType().Name == "Battleship")
            {
                Battleship vessel = new Battleship(vesselName, searchedVessel.MainWeaponCaliber, searchedVessel.Speed);

                vessel.ToggleSonarMode();

                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else if (this.vessels.Models.Contains(searchedVessel) &&
                searchedVessel.GetType().Name == "Submarine")
            {
                Submarine vessel = new Submarine(vesselName, searchedVessel.MainWeaponCaliber, searchedVessel.Speed);

                vessel.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }
            else
            {
                return $"Vessel {vesselName} could not be found.";
            }
        }

        public string VesselReport(string vesselName)
        {
            var vassel = this.vessels.FindByName(vesselName);

            return vassel.ToString();
        }
    }
}
