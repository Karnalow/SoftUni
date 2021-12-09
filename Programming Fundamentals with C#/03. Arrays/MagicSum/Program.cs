using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int firstNumber = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    int secoundNumber = arr[j];

                    if (firstNumber + secoundNumber == number)
                    {
                        Console.WriteLine($"{firstNumber} {secoundNumber}");
                        break;
                    }
                }
            }
        }
    }
}
