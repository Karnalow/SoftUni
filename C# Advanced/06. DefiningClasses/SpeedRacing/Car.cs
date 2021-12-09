using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0.0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void CanCarMoveThatDistance(double amountOfKm)
        {
            double howKmCanDrice = this.FuelAmount / this.FuelConsumptionPerKilometer;

            if (howKmCanDrice >= amountOfKm)
            {
                this.TravelledDistance += amountOfKm;

                double distanceForDrive = amountOfKm * this.FuelConsumptionPerKilometer;

                this.FuelAmount -= distanceForDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
