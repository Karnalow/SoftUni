using System;
using System.Collections.Generic;
using System.Linq;

namespace GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input =
                Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] cmdArg = command.Split();

                string token = cmdArg[0];
                string item = cmdArg[1];

                bool isExist = input.Contains(item);

                if (token == "Urgent")
                {
                    if (!isExist)
                    {
                        input.Insert(0, item);
                    }
                }
                else if (token == "Unnecessary")
                {
                    if (isExist)
                    {
                        input.Remove(item);
                    }
                }
                else if (token == "Correct")
                {
                    if (isExist)
                    {
                        string newItem = cmdArg[2];

                        int index = input.IndexOf(item);

                        input.Remove(item);

                        input.Insert(index, newItem);
                    }
                }
                else if (token == "Rearrange")
                {
                    if (isExist)
                    {
                        input.Remove(item);
                        input.Add(item);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
