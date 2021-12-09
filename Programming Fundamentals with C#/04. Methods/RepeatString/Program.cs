using System;
using System.Text;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());

            RepeatString(str, times);
        }

        public static void RepeatString(string str, int times)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                sb.Append(str);
            }

            Console.WriteLine(sb);
        }
    }
}
