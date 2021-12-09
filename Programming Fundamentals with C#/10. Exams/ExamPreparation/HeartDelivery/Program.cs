using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int jumpedPosition = 0;

            string cmdArg = Console.ReadLine();

            while (cmdArg != "Love!")
            {
                string[] command = cmdArg.Split();
                int length = int.Parse(command[1]);

                jumpedPosition += length;

                if (jumpedPosition >= 0 && jumpedPosition < input.Length)
                {
                    input[jumpedPosition] -= 2; 
                }
                else
                {
                    jumpedPosition = 0;
                    input[jumpedPosition] -= 2;
                }

                if (input[jumpedPosition] == 0)
                {
                    Console.WriteLine($"Place {jumpedPosition} has Valentine's day.");
                }
                else if (input[jumpedPosition] < 0)
                {
                    Console.WriteLine($"Place {jumpedPosition} already had Valentine's day.");
                }

                cmdArg = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {jumpedPosition}.");

            int seccessCount = input.Count(x => x == 0);
            int failCount = input.Count(x => x == 0);

            if (failCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failCount} places.");
            }
        }
    }
}
