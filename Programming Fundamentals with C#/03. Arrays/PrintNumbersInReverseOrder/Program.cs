using System;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                arr[i] = number;
            }

            for (int i = length - 1; i >= 0; i--)
            {
                Console.WriteLine(arr[i] + " ");
            }
        }
    }
}
