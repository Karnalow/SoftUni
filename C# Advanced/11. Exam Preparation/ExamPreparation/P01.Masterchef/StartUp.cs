using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Masterchef
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 150 },
                { "Green salad", 250 },
                { "Chocolate cake", 300 },
                { "Lobster", 400 }
            };

            Dictionary<string, int> result = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            int[] ingredientsValuesItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] freshnessValuesItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredientsValues = new Queue<int>(ingredientsValuesItems);

            Stack<int> freshnessValues = new Stack<int>(freshnessValuesItems);

            while (CanCookContinue(ingredientsValues, freshnessValues))
            {
                if (ingredientsValues.Peek() == 0)
                {
                    ingredientsValues.Dequeue();

                    continue;
                }
                else
                {
                    int ingredientLevel = ingredientsValues.Peek() * freshnessValues.Peek();

                    if (dishes.Any(x => x.Value == ingredientLevel))
                    {
                        foreach (var dish in dishes)
                        {
                            if (dish.Value == ingredientLevel)
                            {
                                result[dish.Key]++;

                                ingredientsValues.Dequeue();
                                freshnessValues.Pop();
                            }
                        }
                    }
                    else
                    {
                        freshnessValues.Pop();

                        int increasedingredientsLevel = ingredientsValues.Peek() + 5;
                        ingredientsValues.Dequeue();
                        ingredientsValues.Enqueue(increasedingredientsLevel);
                    }
                }
            }

            bool isOrderMade = result.All(x => x.Value > 0);

            if (isOrderMade)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            bool isAnyingredientsLeft = ingredientsValues.Any();

            if (isAnyingredientsLeft)
            {
                Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
            }

            foreach (var dish in result.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
            
        }

        private static bool CanCookContinue(Queue<int> ingredientsValues, Stack<int> freshnessValues)
        => freshnessValues.Count != 0 && ingredientsValues.Count != 0;
    }
}
