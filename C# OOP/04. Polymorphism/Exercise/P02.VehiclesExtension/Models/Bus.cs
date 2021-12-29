using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double refueled = 0.8;

        public Bus(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"Bus needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;

            return $"Bus travelled {distance} km";
        }

        public override void Refuel(double quantity)
        {
            this.FuelQuantity += (quantity * refueled);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
