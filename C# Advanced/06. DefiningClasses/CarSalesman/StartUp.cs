using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<Engine> engines = new HashSet<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            Engine(engines, n);

            int m = int.Parse(Console.ReadLine());

            Car(engines, cars, m);

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void Car(HashSet<Engine> engines, List<Car> cars, int m)
        {
            for (int i = 0; i < m; i++)
            {
                string[] carArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Car car = null;

                string model = carArg[0];
                Engine engine = engines.First(e => e.Model == carArg[1]);


                if (carArg.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArg.Length == 3)
                {
                    double weight;

                    bool isWeight = double.TryParse(carArg[2],
                        out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArg[2]);
                    }
                }
                else if (carArg.Length == 4)
                {
                    double weight = double.Parse(carArg[2]);
                    string color = carArg[3];

                    car = new Car(model, engine, weight, color);
                }

                if (car != null)
                {
                    cars.Add(car);
                }
            }
        }

        private static void Engine(HashSet<Engine> engines, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] engineArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Engine engine = null;

                string model = engineArg[0];
                int power = int.Parse(engineArg[1]);

                if (engineArg.Length == 4)
                {
                    int displacement = int.Parse(engineArg[2]);
                    string efficiency = engineArg[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (engineArg.Length == 3)
                {
                    int displacement;

                    bool isDisplacement = int.TryParse(engineArg[2],
                        out displacement);
                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArg[2]);
                    }
                }
                else if (engineArg.Length == 2)
                {
                    engine = new Engine(model, power);
                }

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }
        }
    }
}
