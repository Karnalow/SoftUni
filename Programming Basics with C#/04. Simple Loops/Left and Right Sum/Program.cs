using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var firstSum = 0;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                firstSum = firstSum + x;
            }
            var secondSum = 0;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                secondSum = secondSum + x;
            }
            if (firstSum == secondSum)
            {
                Console.WriteLine("Yes, sum = {0}", firstSum);
            }
            else
            {
                var diff = firstSum - secondSum;
                Console.WriteLine("No, diff = {0}", Math.Abs(diff));
            }
        }
    }
}
