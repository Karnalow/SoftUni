using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());

            int[] quantityOfOrder = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(quantityOfOrder);

            Console.WriteLine(orders.Max());

            for (int i = 0; i < quantityOfOrder.Length; i++)
            {
                if (quantityOfTheFood >= orders.Peek())
                {
                    quantityOfTheFood -= orders.Peek();

                    orders.Dequeue();

                    if (orders.Count == 0)
                    {
                        Console.WriteLine($"Orders complete");

                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orders)}");

                    break;
                }
            }
        }
    }
}
