using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter points:");
            var point = int.Parse(Console.ReadLine());
            var bonus = 0.0;
            if (point <= 100)
            {
                bonus += 5;
            }
            else if (point > 100 && point < 1000)
            {
                bonus = point * 0.2;
            }
            else
            {
                bonus = point * 0.1;
            }
            if (point % 2 == 0)
            {
                bonus += 1;
            }
            else if (point % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine("Bonus points:" + bonus);
            Console.WriteLine("Total points:{0}", bonus + point);
        }
    }
}
