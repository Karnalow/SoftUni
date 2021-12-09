using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintBetweenSign(start, end);
        }

        public static void PrintBetweenSign(char start, char end)
        {
            int startInt = (int)start;
            int endInt = (int)end;

            if (startInt < endInt)
            {
                for (int i = (int)start + 1; i < (int)end; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = (int)end + 1; i < (int)start; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
