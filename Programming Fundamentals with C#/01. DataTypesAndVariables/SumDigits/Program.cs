using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                //int currentNumber = (int)Char.GetNumericValue(input[i]);
                int currentNumber = int.Parse(input[i].ToString());
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
