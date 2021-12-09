using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_after_5_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = int.Parse(Console.ReadLine());
            var mount = int.Parse(Console.ReadLine());
            day = day + 5;
            var daysInTheMount = 31;
            if (mount == 4 || mount == 6 || mount == 9 || mount == 11)
                daysInTheMount = 30;
            else if (mount == 2)
                daysInTheMount = 28;
            if (day > daysInTheMount)
            {
                day = day - daysInTheMount;
                mount++;
                if (mount == 13)
                    mount = 1;
            }
            if (mount < 10)
                Console.WriteLine("{0}.0{1}", day, mount);
            else
                Console.WriteLine("{0}.{1}", day, mount);
        }
    }
}
