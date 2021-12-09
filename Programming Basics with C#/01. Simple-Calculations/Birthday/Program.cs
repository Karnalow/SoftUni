using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lenght:");
            var lenght = int.Parse(Console.ReadLine());
            Console.Write("Width:");
            var width = int.Parse(Console.ReadLine());
            Console.Write("Height:");
            var height = int.Parse(Console.ReadLine());
            Console.Write("Percentage:");
            var percentage = double.Parse(Console.ReadLine());
            percentage = percentage * 0.01;
            var volume = lenght * width * height;
            var liters = volume * 0.001;
            var RealLiters = liters * (1 - percentage);
            if (lenght >= 10 && lenght <= 500 && width >= 10 && width <= 300 && height >= 10 && height <= 200 && percentage >= 0 && percentage <= 100)
            {
                Console.WriteLine(Math.Round(RealLiters, 3));
            }
            else Console.WriteLine("Error");
        }
    }
}
