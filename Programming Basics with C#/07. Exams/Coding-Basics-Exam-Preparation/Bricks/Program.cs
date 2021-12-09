using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var bricks = int.Parse(Console.ReadLine());
            var workers = int.Parse(Console.ReadLine());
            var carsSpace = int.Parse(Console.ReadLine());
            var course = bricks / (double)(workers * carsSpace);
            if (workers * carsSpace >= course)
                Console.WriteLine(Math.Ceiling(course));
            else
                Console.WriteLine(Math.Ceiling(course));
        }
    }
}