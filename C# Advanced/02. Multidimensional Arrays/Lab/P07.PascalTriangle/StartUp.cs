using System;

namespace P07.PascalTriangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n >= 1 && n <= 60)
            {
                int[][] pascal = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    pascal[i] = new int[i + 1];
                }

                for (int i = 0; i < n; i++)
                {
                    pascal[i][0] = 1;
                    pascal[i][pascal[i].Length - 1] = 1;

                    for (int j = 1; j < pascal[i].Length - 1; j++)
                    {
                        pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(string.Join(' ', pascal[i]));
                }
            }
        }
    }
}
