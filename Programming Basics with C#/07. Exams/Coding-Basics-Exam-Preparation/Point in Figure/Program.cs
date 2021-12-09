using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());
            var in1 = (2 <= x && x <= 12) && (1 >= y && y >= -3);
            var in2 = (4 <= x && x <= 10) && (3 >= y && y >= -5);
            if (in1 || in2)
                Console.WriteLine("in");
            else
                Console.WriteLine("out");
        }
    }
}
