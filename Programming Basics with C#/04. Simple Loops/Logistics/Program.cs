using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfMatirial = int.Parse(Console.ReadLine());
            var miniBus = 0;
            var bus = 0;
            var train = 0;
            for (int i = 0; i < numberOfMatirial; i++)
            {
                miniBus++;
                bus++;
                train++;
            }
            var sum = miniBus + bus + train;
            Console.WriteLine("С микробус се превозват два от товарите, общо {0} тона.", miniBus);
            Console.WriteLine("С камион се превозва един от товарите: {0} тона." , bus);
            Console.WriteLine("С влак се превозва един от товарите: {0} тона.", train);
            Console.WriteLine("Сумата от всички товари е: {0} тона.", sum);
        }
    }
}
