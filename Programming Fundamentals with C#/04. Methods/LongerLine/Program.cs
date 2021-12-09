using System;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            var point = ChooseNearnest(x1, y1,
                                       x2, y2,
                                       x3, y3,
                                       x4, y4);

            Console.WriteLine($"{point.Item1}{point.Item2}");
        }

        private static ((double, double),(double, double)) ChooseNearnest(double x1, double y1,
                                                                          double x2, double y2,
                                                                          double x3, double y3,
                                                                          double x4, double y4)
        {
            double c1, c2, c3, c4;

            FindDistance(x1, y1,
                         x2, y2,
                         x3, y3,
                         x4, y4,
                         out c1, out c2,
                         out c3, out c4);

            double line1 = c1 + c2;
            double line2 = c3 + c4;

            (double, double) line1startPoint = (0, 0);
            (double, double) line1endPoint = (0, 0);

            (double, double) line2startPoint = (0, 0);
            (double, double) line2endPoint = (0, 0);

            if (line1 > line2)
            {
                if (c1 >= c2)
                {
                    line1startPoint = (x2, y2);
                    line1endPoint = (x1, y1);
                }
                else if (c1 < c2)
                {
                    line1startPoint = (x1, y1);
                    line1endPoint = (x2, y2);
                }

                return (line1startPoint, line1endPoint);
            }
            else
            {
                if (c3 <= c4)
                {
                    line2startPoint = (x3, y3);
                    line2endPoint = (x4, y4);
                }
                else if (c3 > c4)
                {
                    line2startPoint = (x4, y4);
                    line2endPoint = (x3, y3);
                }

                return (line2startPoint, line2endPoint);
            }
        }

        private static void FindDistance(double x1, double y1,
                                         double x2, double y2,
                                         double x3, double y3,
                                         double x4, double y4,
                                         out double c1, out double c2,
                                         out double c3, out double c4)
        {
            c1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            c1 = Math.Sqrt(c1);

            c2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
            c2 = Math.Sqrt(c2);

            c3 = Math.Pow(x3, 2) + Math.Pow(y3, 2);
            c3 = Math.Sqrt(c3);

            c4 = Math.Pow(x4, 2) + Math.Pow(y4, 2);
            c4 = Math.Sqrt(c4);
        }
    }
}
