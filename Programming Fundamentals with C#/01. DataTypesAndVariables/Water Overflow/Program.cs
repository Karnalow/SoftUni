using System;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int amountInTank = 0;

            for (int i = 0; i < n ; i++)
            {
                int waterToTank = int.Parse(Console.ReadLine());

                bool isFull = waterToTank > 255;
                bool isOverflow = amountInTank + waterToTank > 255;

                if (isFull || isOverflow)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                amountInTank += waterToTank;
            }
            Console.WriteLine(amountInTank);
        }
    }
}
