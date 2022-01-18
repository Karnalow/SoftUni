using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier date = new DateModifier();

            Console.WriteLine(Math.Abs(date.DataDiff(date1, date2)));
        }
    }
}
