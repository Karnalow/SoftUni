using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] informationAboutCars = Console.ReadLine().Split();

                string model = informationAboutCars[0];
                double fuelAmount = double.Parse(informationAboutCars[1]);
                double fuelConsumptionFor1km = double.Parse(informationAboutCars[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                string carModel = command[1];
                double amountOfKm = double.Parse(command[2]);

                Car car = cars.FirstOrDefault(x => x.Model == carModel);

                car.CanCarMoveThatDistance(amountOfKm);

                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TraveledDistance = 0.0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public void CanCarMoveThatDistance(double amountOfKm)
        {
            double howKmCanDrice = this.FuelAmount / this.FuelConsumptionPerKilometer;

            if (howKmCanDrice >= amountOfKm)
            {
                this.TraveledDistance += amountOfKm;

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
