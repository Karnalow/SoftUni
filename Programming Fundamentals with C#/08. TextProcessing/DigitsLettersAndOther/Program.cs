using System;
using System.Collections.Generic;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string nums = string.Empty;
            string letters = string.Empty;
            string characters = string.Empty;

            foreach (var symbol in input)
            {
                if (Char.IsDigit(symbol))
                {
                    nums += symbol.ToString();
                }
                else if (Char.IsLetter(symbol))
                {
                    letters += symbol.ToString();
                }
                else
                {
                    characters += symbol.ToString();
                }
            }

            Console.Write($"{nums}\n{letters}\n{characters}");
        }
    }
}
