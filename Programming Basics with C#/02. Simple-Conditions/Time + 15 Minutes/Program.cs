using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var min = int.Parse(Console.ReadLine());
            min = min + 15;
            hours = (min / 60) + hours;
            min = min % 60;
            hours = hours % 24;
            if (min < 10)
                Console.WriteLine(hours + ":0" + min);
            else
                Console.WriteLine(hours + ":" + min);
        }
    }
}
