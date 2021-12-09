using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int valueInt;
            float valueFloat;
            char valueChar;
            bool valueBoolean;
            string result = "";

            while (input != "END")
            {
                if (int.TryParse(input, out valueInt))
                {
                    result = $"{input} is integer type";
                }
                else if (float.TryParse(input, out valueFloat))
                {
                    result = $"{input} is floating point type";
                }
                else if (char.TryParse(input, out valueChar))
                {
                    result = $"{input} is character type";
                }
                else if (bool.TryParse(input, out valueBoolean))
                {
                    result = $"{input} is boolean type";
                }
                else
                {
                    result = $"{input} is string type";
                }

                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }
    }
}
