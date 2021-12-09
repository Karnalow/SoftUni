using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _C_към_градуси__F
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("rad=");
            var rad = double.Parse(Console.ReadLine());
            var deg = (rad * 180) / Math.PI;
            Console.WriteLine(Math.Round(deg));
        }
    }
}
