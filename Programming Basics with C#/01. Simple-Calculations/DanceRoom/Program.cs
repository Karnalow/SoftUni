using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("дължина:");
            var L = double.Parse(Console.ReadLine());
            Console.Write("ширина:");
            var W = double.Parse(Console.ReadLine());
            Console.Write("страна:");
            var A = double.Parse(Console.ReadLine());
            var size = (L * 100) * (W * 100);
            var wardrobe = (A * 100) * 200;
            var bench = size / 10;
            var freespace = size - wardrobe - bench;
            var dancers = freespace / (40 + 7000);
            if (L>=10 && L<=100 && W >= 10 && W <= 100 && A>=2.00 && A<=20.00)
            {
                Console.WriteLine(Math.Round(dancers));
            }
            else Console.WriteLine("Error");
        }
    }
}
