using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class CrossMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 1.25;

        public CrossMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption
        { get => base.FuelConsumption; set => base.FuelConsumption = value; }

        public override void Drive(double kilometers)
        {
            base.Drive(kilometers);
        }
    }
}
