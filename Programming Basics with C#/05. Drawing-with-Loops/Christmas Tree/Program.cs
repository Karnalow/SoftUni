using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            if (1 <= n && n <= 100)
            {
                for (int row = 0; row <= n; row++)
                {
                    for (int col = 0; col < n - row; col++)
                        Console.Write(" ");
                    for (int col = 0; col < row; col++)
                        Console.Write("*");
                    Console.Write(" | ");
                    for (int col = 0; col < row; col++)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
        }
    }
}
