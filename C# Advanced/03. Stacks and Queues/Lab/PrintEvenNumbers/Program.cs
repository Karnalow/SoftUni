using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(numbers);
            List<int> evenNumbers = new List<int>();

            while (queue.Count > 0)
            {
                int number = queue.Peek();

                if (number % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    evenNumbers.Add(queue.Dequeue());
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
