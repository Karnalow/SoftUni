using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = string.Empty;
            double biggestVolume = 0;

            for (int numerOfKegs = 1; numerOfKegs <= n; numerOfKegs++)
            {
                string keg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = keg;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
