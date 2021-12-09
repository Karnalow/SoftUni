using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_0_100_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var tens = num / 10;
            var ones = num % 10;
            if (num == 1)
                Console.WriteLine("one");
            else if (num == 2)
                Console.WriteLine("two");
            else if (num == 3)
                Console.WriteLine("three");
            else if (num == 4)
                Console.WriteLine("four");
            else if (num == 5)
                Console.WriteLine("five");
            else if (num == 6)
                Console.WriteLine("six");
            else if (num == 7)
                Console.WriteLine("seven");
            else if (num == 8)
                Console.WriteLine("eight");
            else if (num == 9)
                Console.WriteLine("nine");
            else if (num == 10)
                Console.WriteLine("ten");
            else if (num == 11)
                Console.WriteLine("eleven");
            else if (num == 12)
                Console.WriteLine("twelve");
            else if (num == 13)
                Console.WriteLine("thirteen");
            else if (num == 14)
                Console.WriteLine("forteen");
            else if (num == 15)
                Console.WriteLine("fifteen");
            else if (num == 16)
                Console.WriteLine("sixteen");
            else if (num == 17)
                Console.WriteLine("seventeen");
            else if (num == 18)
                Console.WriteLine("eightteen");
            else if (num == 19)
                Console.WriteLine("nineteen");
            else if (num == 0)
                Console.WriteLine("zero");
            else if (num == 100)
                Console.WriteLine("one hundred");
            else if (tens == 2)
                Console.WriteLine("twenty");
            else if (tens == 3)
                Console.WriteLine("thirty");
            else if (tens == 4)
                Console.WriteLine("forty");
            else if (tens == 5)
                Console.WriteLine("fifty");
            else if (tens == 6)
                Console.WriteLine("sixty");
            else if (tens == 7)
                Console.WriteLine("seventy");
            else if (tens == 8)
                Console.WriteLine("eighty");
            else if (tens == 9)
                Console.WriteLine("ninety");
            else if (tens == 1)
                Console.WriteLine("one");
            else if (ones == 2)
                Console.WriteLine("two");
            else if (ones == 3)
                Console.WriteLine("three");
            else if (ones == 4)
                Console.WriteLine("four");
            else if (ones == 5)
                Console.WriteLine("five");
            else if (ones == 6)
                Console.WriteLine("six");
            else if (ones == 7)
                Console.WriteLine("seven");
            else if (ones == 8)
                Console.WriteLine("eigh");
            else if (ones == 9)
                Console.WriteLine("nine");
            else
                Console.WriteLine("invalid number");
        }
    }
}
