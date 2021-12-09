using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> longerList = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToList();

            List<int> shorterList = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < Math.Min(shorterList.Count, longerList.Count); i++)
            {
                    result.Add(longerList[i]);
                    result.Add(shorterList[i]);
            }

            for (int i = Math.Min(shorterList.Count, longerList.Count); i < Math.Max(shorterList.Count, longerList.Count); i++)
            {
                if (i >= shorterList.Count)
                {
                    result.Add(longerList[i]);
                }
                else
                {
                    result.Add(shorterList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
