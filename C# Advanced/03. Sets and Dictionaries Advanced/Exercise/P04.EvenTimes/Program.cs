using System;
using System.Collections.Generic;

namespace P04.EvenTimes
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int numbeer = int.Parse(Console.ReadLine());

                numbers.Add(numbeer);
            }
        }
    }
}
