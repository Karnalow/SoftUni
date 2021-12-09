using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();
            if (figure == "square")
            {
                var side = double.Parse(Console.ReadLine());
                var area = side * side;
                Console.WriteLine(area);
            }
            else if (figure == "rectangle")
            {
                var sideA = double.Parse(Console.ReadLine());
                var sideB = double.Parse(Console.ReadLine());
                var area = sideA * sideB;
                Console.WriteLine(area);
            }
            else if (figure == "circle")
            {
                var radius = double.Parse(Console.ReadLine());
                var area = Math.PI * (radius * radius);
                Console.WriteLine(area);
            }
            else if (figure == "triangle")
            {
                var side = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                var area = (side * h) / 2;
                Console.WriteLine(area);
            }
        }
    }
}
