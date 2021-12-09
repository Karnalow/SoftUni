using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_for_Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var DayOrNight = Console.ReadLine();
            var taxiDay = 0.79 * n + 0.70;
            var taxiNight = 0.90 * n + 0.70;
            var bus = 0.09 * n;
            var train = 0.06 * n;
            if (DayOrNight == "day")
            {
                if (n < 20)
                    Console.WriteLine(taxiDay);
                else if (n >= 20 && n < 100)
                    Console.WriteLine(bus);
                else
                    Console.WriteLine(train);
            }
            if (DayOrNight == "night")
            {
                if (n < 20)
                    Console.WriteLine(taxiNight);
                else if (n >= 20 && n < 100)
                    Console.WriteLine(bus);
                else
                    Console.WriteLine(train);
            }
        }
    }
}
