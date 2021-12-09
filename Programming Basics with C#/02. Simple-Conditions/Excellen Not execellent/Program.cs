using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellen_Not_execellent
{
    class Program
    {
        static void Main(string[] args)
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade >= 5.50 && grade <= 6.00)
            {
                Console.WriteLine("Excellent!");
            }
            else if (grade < 5.50)
            {
                Console.WriteLine("Not excellent.");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
