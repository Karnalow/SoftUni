using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode 
        {
            get => submergeMode;
            set => submergeMode = false;
        }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else if (this.SubmergeMode == true)
            {
                this.SubmergeMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            string onOrOff = string.Empty;

            if (this.SubmergeMode == false)
            {
                onOrOff = "ON";
            }
            else
            {
                onOrOff = "OFF";
            }

            return base.ToString() + Environment.NewLine + $" *Submerge mode: {onOrOff}";
        }
    }
}
