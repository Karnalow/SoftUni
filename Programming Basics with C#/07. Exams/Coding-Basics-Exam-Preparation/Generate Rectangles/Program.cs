using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var printNo = true;
            for (var top = -n; top <= n; top++)
            {
                for (var left = -n; left <= n; left++)
                {
                    for (var bottom = top + 1; bottom <= n; bottom++)
                    {
                        for (var right = left + 1; right <= n; right++)
                        {
                            var width = right - left;
                            var height = bottom - top;
                            var area = width * height; 
                            if (area >= m)
                                Console.WriteLine("({0}, {1}) ({2}, {3}) -> {4}", top, left, bottom, right, area);
                            printNo = false;
                        }
                    }
                }
            }
            if (printNo)
                Console.WriteLine("No");
        }
    }
}
