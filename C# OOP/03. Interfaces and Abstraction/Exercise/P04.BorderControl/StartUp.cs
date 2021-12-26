using System;
using System.Collections.Generic;

namespace P04.BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> citizens = new List<string>();
            List<string> robots = new List<string>();

            while (command[0] != "End")
            {
                if (command.Length == 3)
                {
                    string id = command[2];

                    citizens.Add(id);
                }
                else if (command.Length == 2)
                {
                    string id = command[1];

                    robots.Add(id);
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string digitsForId = Console.ReadLine();

            List<string> correctIds = new List<string>();

            for (int i = 0; i < citizens.Count; i++)
            {
                string substr = citizens[i].Substring(citizens[i].Length - 3);

                if (substr.Contains(digitsForId))
                {
                    correctIds.Add(citizens[i]);
                }
            }

            for (int i = 0; i < robots.Count; i++)
            {
                string substr = robots[i].Substring(robots[i].Length - 3);

                if (substr.Contains(digitsForId))
                {
                    correctIds.Add(robots[i]);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, correctIds));
        }
    }
}
