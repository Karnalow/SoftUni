using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string[] data = Console.ReadLine().Split('/');

            while (data[0] != "end")
            {
                if (data[0] == "Truck")
                {
                    string brand = data[1];
                    string model = data[2];
                    string weight = data[3];

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;

                    catalog.Trucks.Add(truck);
                }
                else
                {
                    string brand = data[1];
                    string model = data[2];
                    string horsePower = data[3];

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;

                    catalog.Cars.Add(car);
                }

                data = Console.ReadLine().Split('/');
            }

            if (catalog.Cars.Any())
            {
                Console.WriteLine("Cars:");

                foreach (Car car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Any())
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    public class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
    }
}
