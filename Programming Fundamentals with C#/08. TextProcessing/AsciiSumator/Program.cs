using System;

namespace AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string summingElements = Console.ReadLine();

            int bigestElement = Math.Max((int)firstChar, (int)secondChar);
            int smallestElement = Math.Min((int)firstChar, (int)secondChar);

            int sum = 0;

            foreach (var element in summingElements)
            {
                if ((int)element < bigestElement && (int)element > smallestElement)
                {
                    sum += (int)element;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
