using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.BirthdayCelebration
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] guestsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] preparedPlatesOfFood = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> guests = new Queue<int>(guestsCapacity);
            Stack<int> plates = new Stack<int>(preparedPlatesOfFood);

            int wastedFood = 0;
            int diff = 0;

            while (IsAnyLeft(guests, plates))
            {
                int feed = plates.Peek() - guests.Peek();

                if (feed >= 0)
                {
                    guests.Dequeue();
                    plates.Pop();

                    wastedFood += feed;
                }
                else
                {
                    diff = feed;
                    plates.Pop();

                    while (diff < 0)
                    {
                        diff = plates.Peek() + diff;
                        plates.Pop();
                    }

                    guests.Dequeue();

                    wastedFood += Math.Abs(diff);
                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }

        private static bool IsAnyLeft(Queue<int> guests, Stack<int> plates)
        {
            return guests.Count != 0 && plates.Count != 0;
        }
    }
}
