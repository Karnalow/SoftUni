using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int d1 = 0; d1 < n; d1++)
            {
                for (int d2 = 0; d2 < n; d2++)
                {
                    for (int d3 = 0; d3 < n; d3++)
                    {
                        char firstChar = (char)('a' + d1);
                        char secondChar = (char)('a' + d2);
                        char thirdChar = (char)('a' + d3);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
