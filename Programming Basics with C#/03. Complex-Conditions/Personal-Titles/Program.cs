using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = double.Parse(Console.ReadLine());
            var gander = Console.ReadLine();
            if (age >= 16 && gander == "m")
                Console.WriteLine("Mr.");
            else if (age < 16 && gander == "m")
                Console.WriteLine("Master");
            else if (age >= 16 && gander == "f")
                Console.WriteLine("Ms.");
            else if (age < 16 && gander == "f")
                Console.WriteLine("Miss");
            else
                Console.WriteLine("Error");
        }
    }
}
