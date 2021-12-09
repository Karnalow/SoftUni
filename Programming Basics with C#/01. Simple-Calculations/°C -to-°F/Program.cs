using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _C__to__F
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("°C=");
            var ce = double.Parse(Console.ReadLine());
            var fe = ce * 1.8 + 32;
            Console.WriteLine(Math.Round(fe, 2));
        }
    }
}
