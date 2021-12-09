using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var period = int.Parse(Console.ReadLine());
            int treatedPatients = 0;
            int untreatedPatients = 0;
            int countOfDoctors = 7;
            for (int day = 1; day <= period; day++)
            {
                var currentPetients = int.Parse(Console.ReadLine());
                if ((day % 3 == 0) && (untreatedPatients > treatedPatients))
                    countOfDoctors++;
                if (currentPetients > countOfDoctors)
                {
                    treatedPatients += countOfDoctors;
                    untreatedPatients += currentPetients - countOfDoctors;
                }
                else
                    treatedPatients += currentPetients;
            }
            Console.WriteLine("Treated patients: " + treatedPatients + ".");
            Console.WriteLine("Untreated patients: " + untreatedPatients + ".");
        }
    }
}
