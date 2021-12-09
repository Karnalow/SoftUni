using System;

namespace ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secoundCharacter = char.Parse(Console.ReadLine());
            char thirdCharacter = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdCharacter} {secoundCharacter} {firstCharacter}");
        }
    }
}
