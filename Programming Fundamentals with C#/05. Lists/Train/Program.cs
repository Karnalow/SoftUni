using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                                         .Split()
                                         .Select(int.Parse)
                                         .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string commnad = Console.ReadLine();

            while (commnad != "end")
            {
                string[] cmdArg = commnad.Split();

                if (cmdArg[0] == "Add")
                {
                    wagons.Add(int.Parse(cmdArg[1]));
                }
                else
                {
                    int passegers = int.Parse(cmdArg[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];
                        bool isEnoughSpace = currentWagon + passegers <= maxCapacity;

                        if (isEnoughSpace)
                        {
                            wagons[i] += passegers;
                            break;
                        }
                    }
                }
                commnad = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
