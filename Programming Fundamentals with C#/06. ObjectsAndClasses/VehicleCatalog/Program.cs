using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArgs = command.Split();

                string type = cmdArgs[0].ToLower();
                string model = cmdArgs[1];
                string color = cmdArgs[2].ToLower();
                int horsePower = int.Parse(cmdArgs[3]);

                Vehicle currentvehicle = new Vehicle(type, model, color, horsePower);

                catalogue.Add(currentvehicle);

                command = Console.ReadLine();
            }

            string secondCommnad = Console.ReadLine();

            while(secondCommnad != "Close the Catalogue")
            {
                string modelType = secondCommnad;

                Vehicle printCar = catalogue.First(x => x.Model == modelType);

                Console.WriteLine(printCar);

                secondCommnad = Console.ReadLine();
            }

            List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

            double totalCarsHorsePower = onlyCars.Sum(x => x.HorsePower);
            double totalTrucksHorsePower = onlyTrucks.Sum(x => x.HorsePower);

            double avarageCarHorsePower = 0.00;
            double avarageTruckHorsePower = 0.00;

            if (onlyCars.Count > 0)
            {
                avarageCarHorsePower = totalCarsHorsePower / onlyCars.Count;
            }
            if (onlyTrucks.Count > 0)
            {
                avarageTruckHorsePower = totalTrucksHorsePower / onlyTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {avarageCarHorsePower:f2}.\nTrucks have average horsepower of: {avarageTruckHorsePower:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {(Type == "car" ? "Car" : "Truck")}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
