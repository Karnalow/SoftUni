using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] informationAboutCars = Console.ReadLine().Split();

                string model = informationAboutCars[0];
                double fuelAmount = double.Parse(informationAboutCars[1]);
                double fuelConsumptionPerKilometer = double.Parse(informationAboutCars[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

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
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
