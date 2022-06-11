using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();

                box.AddMethod(element);
            }

            string value = Console.ReadLine();

            Console.WriteLine(box.CountMethodString(value));
        }
    }
}
