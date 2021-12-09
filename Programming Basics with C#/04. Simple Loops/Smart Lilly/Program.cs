using System;

namespace Smart_Lilly
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());
            var washMachinePrice = double.Parse(Console.ReadLine());
            var pricePerToy = int.Parse(Console.ReadLine());
            int numberOfToys = 0;
            int savedMoney = 0;
            int moneyForBirthday = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += (moneyForBirthday - 1);
                    moneyForBirthday += 10;
                }
                else
                    numberOfToys++;
            }
            savedMoney += numberOfToys * pricePerToy;
            Console.WriteLine(savedMoney >= washMachinePrice ? $"Yes! {(savedMoney - washMachinePrice):0.00}" : $"No! {(washMachinePrice - savedMoney):0.00}");
        }
    }
}
