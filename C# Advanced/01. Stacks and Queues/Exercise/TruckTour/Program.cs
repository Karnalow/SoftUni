using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }

            int index = 0;
            int length = pumps.Count;

            for (int i = 0; i < length; i++)
            {
                bool isCompleted = true;
                int totalAmount = 0;

                for (int j = 0; j < length; j++)
                {
                    string currentPump = pumps.Dequeue();
                    int[] currentPumpsValue =
                        currentPump.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    int currentAmount = currentPumpsValue[0];
                    int distance = currentPumpsValue[1];

                    totalAmount += currentAmount;

                    if (totalAmount >= distance)
                    {
                        totalAmount -= distance;
                    }
                    else
                    {
                        isCompleted = false;
                    }
                    
                    pumps.Enqueue(currentPump);
                }

                if (isCompleted)
                {
                    index = i;
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
