using System;
using System.Linq;

namespace EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            
            bool diff = true;
            int diffIndex = -1;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    diff = false;
                    diffIndex = i;
                    break;
                }
            }

            if (diff)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    sum += arr1[i];
                }

                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {diffIndex} index");
            }
        }
    }
}
