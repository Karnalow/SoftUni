using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Same_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first word:");
            var word = Console.ReadLine();
            Console.Write("Enter secound word:");
            var checker = Console.ReadLine();
            word = word.ToLower();
            checker = checker.ToLower();
            if (word == checker)
            {
                Console.WriteLine("yes");
            }
            else if (word != checker)
            {
                Console.WriteLine("no");
            }
            else Console.WriteLine("You are idiot!");
        }
    }
}
