using System;

namespace The_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetters = Console.ReadLine();
            var secoundLetters = Console.ReadLine();
            var numbes = int.Parse(Console.ReadLine());
            var count = 1;
            for (int d1 = 0; d1 <= 9; d1++)
            {
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        for (int d4 = 0; d4 <= 9; d4++)
                        {
                            if (d1 + d2 + d3 + d4 == (d1 * d3) - numbes)
                            {
                                if (count <= numbes)
                                {
                                    Console.Write($"{firstLetters}{d1}{d2}{d3}{d4}{secoundLetters} ");
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
