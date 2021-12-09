using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativesReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.RemoveAt(i--);
                }
            }

            nums.Reverse();

            if (nums.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
