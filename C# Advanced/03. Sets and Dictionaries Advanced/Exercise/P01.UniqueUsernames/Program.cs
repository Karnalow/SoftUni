using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                if (!names.Contains(name))
                {
                    names.Enqueue(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
