using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] nameTownInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] nameBeerInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = nameBeerInput[0];
            int liters = int.Parse(nameBeerInput[1]);

            string[] numbersInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int integer = int.Parse(numbersInput[0]);
            double doubleNumber = double.Parse(numbersInput[1]);

            MyTuple<string, string> nameTown =
            new MyTuple<string, string>
            ($"{nameTownInput[0]} {nameTownInput[1]}", nameTownInput[2]);

            MyTuple<string, int> nameBeer =
            new MyTuple<string, int>(name, liters);

            MyTuple<int, double> numbers =
            new MyTuple<int, double>(integer, doubleNumber);

            Console.WriteLine(nameTown.GetItems());
            Console.WriteLine(nameBeer.GetItems());
            Console.WriteLine(numbers.GetItems());
        }
    }
}
