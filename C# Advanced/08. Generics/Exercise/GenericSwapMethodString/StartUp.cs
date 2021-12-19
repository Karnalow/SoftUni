using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();
 
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                if (!list.Contains(name))
                {
                    list.Add(name);
                }
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstElementIndex = indexes[0];
            int secondElementIndex = indexes[1];

            Box<string>.SwapsElements(list, firstElementIndex, secondElementIndex);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
