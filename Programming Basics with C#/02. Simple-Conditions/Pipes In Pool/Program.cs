using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            var volume = double.Parse(Console.ReadLine());
            var pipe1 = double.Parse(Console.ReadLine());
            var pipe2 = double.Parse(Console.ReadLine());
            var hour = double.Parse(Console.ReadLine());
            double water = (pipe1 + pipe2) * hour;
            if (water <= volume)
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                    Math.Truncate(water / volume * 100),
                    Math.Truncate(pipe1 * hour / water * 100),
                    Math.Truncate(pipe2 * hour / water * 100));
            else
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", hour, water - volume);
        }
    }
}
