using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int EvenSum = 0;
            int OddSum = 0;
            int diff = 0;
            bool areTheSumsEqual = true;
            for (int position = 1; position <= n; position++)
            {
                int currentNumberOne = int.Parse(Console.ReadLine());
                int currentNumberTwo = int.Parse(Console.ReadLine());

                if (position % 2 == 0)
                {
                    EvenSum = currentNumberOne + currentNumberTwo;
                }
                else
                {
                    OddSum = currentNumberTwo + currentNumberOne;
                }

                if (position > 1 && Math.Abs(EvenSum - OddSum) > diff)
                {
                    diff = Math.Abs(EvenSum - OddSum);
                    areTheSumsEqual = false;
                }
            }

            if (areTheSumsEqual == true)
            {
                Console.WriteLine($"Yes, value={OddSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
