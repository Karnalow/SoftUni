using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DataType(input);
        }

        private static void DataType(string input)
        {
            if (input == "int")
            {
                int num = int.Parse(Console.ReadLine());

                Console.WriteLine(num * 2);
            }
            else if (input == "real")
            {
                double num = double.Parse(Console.ReadLine());

                Console.WriteLine($"{(num * 1.5):f2}");
            }
            else if (input == "string")
            {
                string String = Console.ReadLine();

                Console.WriteLine($"${String}$");
            }
        }
    }
}
