using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }

        public bool SonarMode 
        {
            get => sonarMode;
            set => sonarMode = false;
        }

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if (this.SonarMode == true)
            {
                this.SonarMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 300)
            {
                this.ArmorThickness = 300;
            }
        }

        public override string ToString()
        {
            string onOrOff = string.Empty;

            if (this.SonarMode == false)
            {
                onOrOff = "ON";
            }
            else
            {
                onOrOff = "OFF";
            }

            return base.ToString() + Environment.NewLine + $" *Sonar mode: {onOrOff}";
        }
    }
}
