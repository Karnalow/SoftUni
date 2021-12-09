using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            double cntP1 = 0;
            double cntP2 = 0;
            double cntP3 = 0;
            double cntP4 = 0;
            double cntP5 = 0;
            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num < 200)
                    cntP1++;
                else if (num >= 200 && num <= 399)
                    cntP2++;
                else if (num >= 400 && num <= 599)
                    cntP3++;
                else if (num >= 600 && num <= 799)
                    cntP4++;
                else
                    cntP5++;
                p1 = Math.Round(cntP1 * 100 / n, 2);
                p2 = Math.Round(cntP2 * 100 / n, 2);
                p3 = Math.Round(cntP3 * 100 / n, 2);
                p4 = Math.Round(cntP4 * 100 / n, 2);
                p5 = Math.Round(cntP5 * 100 / n, 2);
            }
            Console.WriteLine($"{p1}%");
            Console.WriteLine($"{p2}%");
            Console.WriteLine($"{p3}%");
            Console.WriteLine($"{p4}%");
            Console.WriteLine($"{p5}%");
        }
    }
}
