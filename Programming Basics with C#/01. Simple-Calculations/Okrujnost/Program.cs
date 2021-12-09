using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okrujnost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("r=");
            var r = double.Parse(Console.ReadLine());
            var area = Math.PI * r * r;
            Console.WriteLine("Area=" + area);
            var peremitur = 2 * Math.PI * r;
            Console.WriteLine("Peremitur" + peremitur);
        }
    }
}
