using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"([#]|[|])(?<itemName>[A-Za-z ]+)\1(?<expirationDate>(?<day>(?:[0-2][0-9])|(?:3[01]))/(?<mont>(?:[0][1-9])|(?:1[012]))/(?<year>\d{2}))\1(?<calories>(?:\d{1,4}|10000))\1");

            var matches = pattern.Matches(input);

            int totalCalories = 0;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match match in matches)
            {
                string itemName = match.Groups["itemName"].Value;
                string expirationDate = match.Groups["expirationDate"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {calories}");
            }
        }
    }
}
