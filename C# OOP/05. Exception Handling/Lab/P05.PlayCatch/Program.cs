using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> inputCopy = new List<int>(input);

            int countOfEx = 0;

            while (countOfEx != 3)
            {
                try
                {
                    string[] command = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (command[0] == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);

                        inputCopy[index] = element;
                    }
                    else if (command[0] == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        Console.WriteLine(string.Join(", ", inputCopy.GetRange(startIndex, (endIndex - startIndex) + 1)));
                    }
                    else if (command[0] == "Show")
                    {
                        int index = int.Parse(command[1]);

                        Console.WriteLine(inputCopy.ElementAt(index));
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");

                    countOfEx++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");

                    countOfEx++;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("The index does not exist!");

                    countOfEx++;
                }
            }

            Console.WriteLine(string.Join(", ", inputCopy));
        }
    }
}
