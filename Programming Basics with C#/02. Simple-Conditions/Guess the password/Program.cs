using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_password
{
    class Program
    {
        static void Main(string[] args)
        {
            var pass = Console.ReadLine();
            if (pass == "s3cr3t!P@ssw0rd")
                Console.WriteLine("Welcome");
            else if (pass != "s3cr3t!P@ssw0rd")
                Console.WriteLine("Wrong password!");
        }
    }
}
