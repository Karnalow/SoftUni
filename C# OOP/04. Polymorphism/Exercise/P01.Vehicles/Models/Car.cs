using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double airConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + airConsumption)
        {
        }

        public override string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                return $"Car needs refueling";
            }

            this.FuelQuantity -= distance * this.FuelConsumption;

            return $"Car travelled {distance} km";
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
