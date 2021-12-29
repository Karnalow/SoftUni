using System;

namespace P02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    array[i] = ReadNumber();


                    if (array[i] <= start || array[i] > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");

                    i--;

                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {array[i]} - {end}!");

                    i--;

                    continue;
                }


                start = array[i];
            }

            Console.WriteLine();

            Console.WriteLine(string.Join(", ", array));
        }

        public static int ReadNumber()
        {
            string input = Console.ReadLine();
            int num;

            while (!int.TryParse(input, out num))
            {
                throw new FormatException();
            }


            return num;
        }
    }
}
