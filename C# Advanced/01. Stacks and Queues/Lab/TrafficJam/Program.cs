using System;
using System.Collections.Generic;

namespace TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPassGreenLight = int.Parse(Console.ReadLine());
            int passedCars = 0;

            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCarsToPassGreenLight; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string car = cars.Dequeue();
                            passedCars++;

                            Console.WriteLine($"{car} passed!");
                        }
                    }
                }
                else
                {
                    string car = command;

                    cars.Enqueue(car);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
