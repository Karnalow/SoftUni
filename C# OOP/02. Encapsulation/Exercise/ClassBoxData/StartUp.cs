﻿using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;

            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);

                return;
            }

            Console.WriteLine(box);
        }
    }
}
