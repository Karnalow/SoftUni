using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var testHour = int.Parse(Console.ReadLine());
            var testMinutes = int.Parse(Console.ReadLine());
            var comeHour = int.Parse(Console.ReadLine());
            var comeMinutes = int.Parse(Console.ReadLine());
            string late = "Late";
            string onTime = "On time";
            string early = "Early";
            int testTime = (testHour * 60) + testMinutes;
            int comeTime = (comeHour * 60) + comeMinutes;
            int totalMinutesDifference = comeTime - testTime;
            string studentCome = late;
            if (totalMinutesDifference < -30)
                studentCome = early;
            else if (totalMinutesDifference <= 30)
                studentCome = onTime;
            string result = string.Empty;
            if (totalMinutesDifference != 0)
            {
                int hoursDifference = Math.Abs(totalMinutesDifference / 60);
                int minutesDifference = Math.Abs(totalMinutesDifference % 60);
                if (hoursDifference > 0)
                    result = string.Format("{0}:{1:00} hours", hoursDifference, minutesDifference);
                else
                    result = minutesDifference + " minutes";
                if (totalMinutesDifference < 0)
                    result += " before the start";
                else
                    result += " after the start";
            }
            Console.WriteLine(studentCome);
            if (!string.IsNullOrEmpty(result))
                Console.WriteLine(result);
        }
    }
}
