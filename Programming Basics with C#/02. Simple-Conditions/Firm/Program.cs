using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectHours = int.Parse(Console.ReadLine());
            var availableDays = int.Parse(Console.ReadLine());
            var overtimeWorkers = int.Parse(Console.ReadLine());
            double workDays = 0.9 * projectHours;
            double overtimeHours = overtimeWorkers * 2 * availableDays;
            double workHours = overtimeWorkers * 2 * availableDays;
            double totalHours = Math.Floor(workDays * 8 + overtimeHours);
            if (projectHours >= totalHours)
                Console.WriteLine("Yes!{0} hours left.", projectHours - totalHours);
            else
                Console.WriteLine("Not enough time!{0} hours needed.", projectHours - workHours);
        }
    }
}
