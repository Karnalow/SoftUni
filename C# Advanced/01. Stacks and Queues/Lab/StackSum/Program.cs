using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbersAsString = Console.ReadLine();

            Stack<int> numbers = new Stack<int>();

            string[] numbersList = numbersAsString
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbersList)
            {
                numbers.Push(int.Parse(number));
            }

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0].ToLower() == "remove")
                {
                    int numberOfElementsToRemove = int.Parse(command[1]);

                    if (numberOfElementsToRemove <= numbers.Count)
                    {
                        for (int i = 0; i < numberOfElementsToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
