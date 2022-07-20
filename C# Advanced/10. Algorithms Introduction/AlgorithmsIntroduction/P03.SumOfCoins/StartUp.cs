﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.SumOfCoins
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");

            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortedCoins = coins
           .OrderByDescending(c => c)
           .ToList();

            var chosenCoins = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (currentSum != targetSum && coinIndex < sortedCoins.Count)
            {
                int currentCoinValue = sortedCoins[coinIndex];
                int remainingSum = targetSum - currentSum;
                int numberOfCoinToTake = remainingSum / currentCoinValue;

                if (numberOfCoinToTake > 0)
                {
                    chosenCoins[currentCoinValue] = numberOfCoinToTake;

                    currentSum += currentCoinValue * numberOfCoinToTake;
                }

                coinIndex++;

            }

            if (currentSum == targetSum)
            {
                return chosenCoins;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
