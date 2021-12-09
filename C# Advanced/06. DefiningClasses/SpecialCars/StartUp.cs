using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> car = new List<Car>();

            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                string[] cmdArg = command.Split();

                int year = int.Parse(cmdArg[0]);
                double pressure = double.Parse(cmdArg[1]);

                Tire tires = new Tire(year, pressure);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] cmdArg = command.Split();

                int horsePower = int.Parse(cmdArg[0]);
                double cubicCapacity = double.Parse(cmdArg[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] cmdArg = command.Split();

                string make = cmdArg[0];
                string model = cmdArg[1];
                int year = int.Parse(cmdArg[2]);
                double fuelQuantity = double.Parse(cmdArg[3]);
                double fuelConsumption = double.Parse(cmdArg[4]);
                int engineIndex = int.Parse(cmdArg[5]);
                int tiresIndex = int.Parse(cmdArg[6]);

                Car cars = new Car(make, model, year, fuelQuantity, fuelConsumption, engineIndex, tiresIndex);

                car.Add(cars);

                command = Console.ReadLine();
            }

            foreach (var cars in car)
            {
                if (true)
                {

                }
            }
        }
    }
}
