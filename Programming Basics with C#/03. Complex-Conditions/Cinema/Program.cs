using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var film = Console.ReadLine().ToLower();
            var r = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            if (film == "premiere")
            {
                var Premiere = 12.00;
                Console.WriteLine(Math.Round(Premiere * (r * c), 2) + " " + "leva");
            }
            else if (film == "normal")
            {
                var Normal = 7.50;
                Console.WriteLine(Math.Round(Normal * (r * c), 2) + " " + "leva");
            }
            else if (film == "discount")
            {
                var Discount = 5.00;
                Console.WriteLine(Math.Round(Discount * (r * c), 2) + " " + "leva");
            }
        }
    }
}
