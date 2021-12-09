using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Car> cars = new HashSet<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Car(cars);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                HashSet<Car> result = cars.Where(c => c.Cargo.Type == "fragile" &&
                                                c.Tires.Any(t => t.Pressure < 1))
                                                    .ToHashSet();

                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
            else if (command == "flammable")
            {
                HashSet<Car> result = cars.Where(c => c.Cargo.Type == "flammable" &&
                                                c.Engine.Power > 250)
                                                    .ToHashSet();

                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }

        private static void Car(HashSet<Car> cars)
        {
            string[] carArg = Console.ReadLine().Split();

            string model = carArg[0];

            int engineSpeed = int.Parse(carArg[1]);
            int enginePower = int.Parse(carArg[2]);

            int cargoWeight = int.Parse(carArg[3]);
            string cargoType = carArg[4];

            double tire1Pressure = double.Parse(carArg[5]);
            int tire1Age = int.Parse(carArg[6]);

            double tire2Pressure = double.Parse(carArg[7]);
            int tire2Age = int.Parse(carArg[8]);

            double tire3Pressure = double.Parse(carArg[9]);
            int tire3Age = int.Parse(carArg[10]);

            double tire4Pressure = double.Parse(carArg[11]);
            int tire4Age = int.Parse(carArg[12]);

            Car car = new Car(model, engineSpeed, enginePower,
            cargoWeight, cargoType, tire1Pressure,
            tire1Age, tire2Pressure, tire2Age,
            tire3Pressure, tire3Age, tire4Pressure, tire4Age);

            cars.Add(car);
        }
    }
}
