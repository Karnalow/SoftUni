using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter even number: ");
            var num = int.Parse(Console.ReadLine());
            while (num % 2 != 0)
            {
                Console.WriteLine("The number is not even.");
                try
                {
                    Console.Write("Enter even number: ");
                    num = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            Console.WriteLine("Even number entered: {0}", num);
        }
    }
}
