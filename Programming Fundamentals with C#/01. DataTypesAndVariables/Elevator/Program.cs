using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int coursesCount = 1;

            while (numberOfPeople > elevatorCapacity)
            {
                numberOfPeople -= elevatorCapacity;
                coursesCount++;
            }

            Console.WriteLine(coursesCount);
        }
    }
}
