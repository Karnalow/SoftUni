using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> timesToPass = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            int finishline = timesToPass[timesToPass.Count / 2];
            double timeCar1 = 0;
            double timeCar2 = 0;

            for (int i = 0; i < timesToPass.Count / 2; i++)
            {
                timeCar1 += timesToPass[i];

                if (timesToPass[i] == 0)
                {
                    timeCar1 *= 0.8;
                }
            }
            for (int i = timesToPass.Count - 1; i > timesToPass.Count / 2; i--)
            {
                timeCar2 += timesToPass[i];

                if (timesToPass[i] == 0)
                {
                    timeCar2 *= 0.8;
                }
            }

            if (timeCar1 > timeCar2)
            {
                Console.WriteLine($"The winner is right with total time: {Math.Round(timeCar2, 1)}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {Math.Round(timeCar1, 1)}");
            }
        }
    }
}
