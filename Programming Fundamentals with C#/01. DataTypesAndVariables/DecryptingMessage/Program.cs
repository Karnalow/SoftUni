using System;

namespace DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string result = "";

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                char newLetter = (char)((int)letter + key);

                result += newLetter;
            }

            Console.WriteLine(result);
        }
    }
}
