using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo);

                cars.Add(car);
            }

            string command = Console.ReadLine(); 

            if (command == "fragile")
            {
                cars = cars.Where(x => x.Cargo.Type == command).Where(x => x.Cargo.Weight < 1000).ToList();
            }
            else if (command == "flamable")
            {
                cars = cars.Where(x => x.Cargo.Type == command).Where(x => x.Engine.Power > 250).ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
