using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex emailRegex = 
            new Regex(@"(?<=\s)(?<user>([a-z]+|\d+)(\.|_|\-)?([a-z]+|\d+))\@(?<host>([a-z]+|\d+)(\.|\-)?([a-z]+|\d+)\.?[a-z]+\.[a-z]+)\b");

            string text = Console.ReadLine();

            var matches = emailRegex.Matches(text);

            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
