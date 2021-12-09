using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([+359]{4})([- ])(2)(\2)(\d{3})(\2)(\d{4})\b";

            string phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, pattern);

            var matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(m => m.Value.Trim())
                .ToArray();

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}
