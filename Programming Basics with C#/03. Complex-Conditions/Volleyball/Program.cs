using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine().ToLower();
            var p = int.Parse(Console.ReadLine());
            var h = int.Parse(Console.ReadLine());
            var Sofiq = 46 * 0.75;
            double celebrate = p * 2 / 3;
            var all = Sofiq + h + celebrate;
            if (year == "leap")
            {
                var leap = all * 0.15;
                var allPlus = leap + all;
                Console.WriteLine(Math.Truncate(allPlus));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Truncate(all));
            }
        }
    }
}
