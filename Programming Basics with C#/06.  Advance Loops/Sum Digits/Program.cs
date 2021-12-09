using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var sum = 0;
            while (num > 0)
            {
                var digit = num % 10;
                sum = sum + digit;
                num = num / 10;
            }
            Console.WriteLine(sum);
        }
    }
}
