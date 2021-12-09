using System;

namespace TheSmallestAndLargestP_thNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int min = input;
            int max = (input * input) - 1;
            int diff = max - min;

            Console.WriteLine($"MIN = {min}\nMAX = {max}\nDIFF = {diff}");
        }
    }
}
