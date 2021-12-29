using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double airConsumption = 1.6;
        private const double refueled = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + airConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"Truck needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;

            return $"Truck travelled {distance} km";
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
