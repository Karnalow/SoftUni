using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_2BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("$");
            var USD = double.Parse(Console.ReadLine());
            var BGN = USD * 1.79549;
            Console.WriteLine(Math.Round(BGN, 2) + "BGN");
        }
    }
}
