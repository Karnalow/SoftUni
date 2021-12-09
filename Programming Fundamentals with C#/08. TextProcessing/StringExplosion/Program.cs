using System;

namespace StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string feild = Console.ReadLine();

            int bomb = 0;

            for (int i = 0; i < feild.Length; i++)
            {
                char currentChar = feild[i];

                if (currentChar == '>')
                {
                    bomb += int.Parse(feild[i + 1].ToString());

                    continue;
                }

                if (bomb > 0)
                {
                    feild = feild.Remove(i, 1);

                    i--;
                    bomb--;
                }
            }

            Console.WriteLine(feild);
        }
    }
}
