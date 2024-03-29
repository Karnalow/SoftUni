﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            string command = Console.ReadLine().ToUpper();
            
            while (command != "END")
            {
                string[] cmdArgs = command.Split();

                if (cmdArgs[0] == "ADD")
                {
                    int element = int.Parse(cmdArgs[1]);
                    numbers.Add(element);
                }
                else if (cmdArgs[0] == "INSERT")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    if (InvalidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (cmdArgs[0] == "REMOVE")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (InvalidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (cmdArgs[0] == "SHIFT")
                {
                    int rotation = int.Parse(cmdArgs[2]);

                    if (cmdArgs[1] == "LEFT")
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = numbers[0];

                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }

                            numbers[numbers.Count - 1] = firstElement;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rotation; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];

                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }

                            numbers[0] = lastElement;
                        }
                    }
                }
                command = Console.ReadLine().ToUpper();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        public static bool InvalidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
