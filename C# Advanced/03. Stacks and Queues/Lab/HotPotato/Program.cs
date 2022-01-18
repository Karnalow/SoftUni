﻿using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int everyNth = int.Parse(Console.ReadLine());

            Queue<string> kids = new Queue<string>();

            foreach (var name in names)
            {
                kids.Enqueue(name);
            }

            while (kids.Count > 1)
            {
                for (int i = 0; i < everyNth - 1; i++)
                {
                   string potatoKid = kids.Dequeue();

                   kids.Enqueue(potatoKid);
                }

                string kidToRemove = kids.Dequeue();

                Console.WriteLine($"Removed {kidToRemove}");
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
