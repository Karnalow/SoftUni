using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceZ = double.Parse(Console.ReadLine());
            var priceP = double.Parse(Console.ReadLine());
            var kgZ = int.Parse(Console.ReadLine());
            var kgP = int.Parse(Console.ReadLine());
            var priceA = priceZ * kgZ;
            var priceB = priceP * kgP;
            if (priceZ > 0.00 && priceZ <= 1000.00 && priceP > 0.00 && priceP <= 1000.00 && kgP > 0.00 && kgP <= 1000.00 && kgZ > 0.00 && kgZ <= 1000.00)
                Console.WriteLine((priceA + priceB) / 1.94);
            else
                Console.WriteLine("Error");
        }
    }
}
