using System;

namespace Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            var holydays = int.Parse(Console.ReadLine());
            var workingDays = 365 - holydays;
            var totalPlayMinutes = (workingDays * 63) + (holydays * 127);
            var difference = Math.Abs(totalPlayMinutes - 30000);
            var hours = difference / 60;
            var minutes = difference % 60;
            if (totalPlayMinutes > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours, minutes);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
            }
        }
    }
}
