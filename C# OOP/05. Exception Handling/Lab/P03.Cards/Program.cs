using System;
using System.Collections.Generic;

namespace P03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = new List<string>()
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            List<string> suits = new List<string>()
            {
                "H", "C", "D", "S" 

                //"\u2660", "\u2665", "\u2666", "\u2663"
            };

            Dictionary<string, string> validCards = new Dictionary<string, string>();

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardInfo = input[i].Split(new char[] { ' ' });

                string card = cardInfo[0];
                string suit = cardInfo[1];

                try
                {
                    if (cards.Contains(card) && suits.Contains(suit))
                    {
                        validCards.Add(card, suit);
                    }
                    else
                    {
                        throw new Exception("Invalid card!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            foreach (var validCard in validCards)
            {
                if (validCard.Value == "H")
                {
                    Console.Write($"[{validCard.Key}\u2665] ");
                }
                else if (validCard.Value == "D")
                {
                    Console.Write($"[{validCard.Key}\u2666] ");
                }
                else if (validCard.Value == "S")
                {
                    Console.Write($"[{validCard.Key}\u2660] ");
                }
                else if (validCard.Value == "C")
                {
                    Console.Write($"[{validCard.Key}\u2663] ");
                }
            }
        }
    }
}
