using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesInTheBox);

            int sum = 0;
            int racks = 0;

            while (stack.Count != 0)
            {
                int number = stack.Peek();

                sum += number;

                if (capacity >= sum)
                {
                    stack.Pop();
                }
                if (capacity < sum || stack.Count == 0)
                {
                    racks++;

                    sum = 0;
                }
                if (capacity == sum)
                {
                    racks++;

                    sum = 0;
                }
            }

            Console.WriteLine(racks);

            //5 4 8 6 3 8 7 7 9
        }
    }
}
