using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secound_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var time1 = int.Parse(Console.ReadLine());
            var time2 = int.Parse(Console.ReadLine());
            var time3 = int.Parse(Console.ReadLine());
            var time = time1 + time2 + time3;
            var min = time / 60;
            time = time % 60;
            if (time < 10)
            {
                Console.WriteLine(min + ":0" + time);
            }
            else
            {
                Console.WriteLine(min + ":" + time);
            }
        }
    }
}
