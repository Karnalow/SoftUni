using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());
            var x2 = 2 * h;
            var y2 = 4 * h;
            var x1 = h;
            var y1 = h;
            var X2 = 3 * h;
            var Y2 = h;
            var X1 = h * 0;
            var Y1 = h * 0;
            var top = (x == x1) && (y >= y1) && (y <= y2);
            var bottom = (x == x2) && (y >= y1) && (y <= y2);
            var right = (y == y1) && (x >= x1) && (x <= x2);
            var left = (y == y2) && (x >= x1) && (x <= x2);
            var Top = (x == X1) && (y >= Y1) && (y <= Y2);
            var Bottom = (x == X2) && (y >= Y1) && (y <= Y2);
            var Right = (y == Y1) && (x >= X1) && (x <= X2);
            var Left = (y == Y2) && (x >= X1) && (x <= X2);
            if (x > x1 && x < x2 && y > y1 && y < y2 || x > X1 && x < X2 && y > Y1 && y < Y2)
                Console.WriteLine("inside");
            else if (top || bottom || right || left || Top || Bottom || Right || Left)
                Console.WriteLine("border");
            else Console.WriteLine("outside");
        }
    }
}
