﻿using System;
using System.Collections.Generic;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();

                var box = new Box<string>(value);

                Console.WriteLine(box);
            }
        }
    }
}
