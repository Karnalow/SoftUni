﻿using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+\b \b[A-Z][a-z]+\b";

            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            var matches = regex.Matches(text);

            Console.WriteLine(string.Join(' ', matches));
        }
    }
}
