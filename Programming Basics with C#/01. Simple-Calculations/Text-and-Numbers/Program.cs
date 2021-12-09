using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_and_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your first name:");
            var firstname = Console.ReadLine();
            Console.Write("Enter your last name:");
            var lastname = Console.ReadLine();
            Console.Write("Enter your age:");
            var age = Console.ReadLine();
            Console.Write("Enter your town:");
            var town = Console.ReadLine();
            Console.WriteLine("You are {0} {1} and you are {2}-years old from {3}.", firstname, lastname, age, town);
        }
    }
}
