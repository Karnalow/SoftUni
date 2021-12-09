using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inches2Cm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("inch=");
            var inhc = double.Parse(Console.ReadLine());
            var cm = inhc * 2.54;
            Console.WriteLine("cm=" + cm );
        }
    }
}
