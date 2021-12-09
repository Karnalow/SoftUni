using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Брой правоъгълни маси:");
            var table = int.Parse(Console.ReadLine());
            Console.Write("Дължина на правоъгълните маси в метри:");
            var tablelength = double.Parse(Console.ReadLine());
            Console.Write("Широчина на правоъгълните маси:");
            var tablewidth = double.Parse(Console.ReadLine());
            var area = table * (tablelength + 2 * 0.30) * (tablewidth + 2 * 0.30);
            var areaK = table * (tablelength / 2) * (tablelength / 2);
            var USD = area * 7 + areaK * 9;
            var BGN = USD * 1.85;
            if (table>0 && table<=500 && tablelength > 0.00 && tablelength<=3.00 && tablewidth>0.00 && tablewidth<=3.00)
            {
                Console.WriteLine(Math.Round(USD, 2) + " " + "USD");
                Console.WriteLine(Math.Round(BGN, 2) + " " + "BGN");
            }
            else Console.WriteLine("Error");
        }
    }
}
