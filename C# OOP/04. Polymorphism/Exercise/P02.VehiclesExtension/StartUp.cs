using P02.VehiclesExtension.Models;
using System;

namespace P02.VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            string[] busInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdArg = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);

                if (cmdArg == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(value));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(value));
                    }
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(bus.Drive(value));
                    }
                }
                else if (cmdArg == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(value);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
