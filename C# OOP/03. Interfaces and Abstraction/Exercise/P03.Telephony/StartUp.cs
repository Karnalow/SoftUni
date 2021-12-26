using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03.Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.All(x => char.IsDigit(x)))
                {
                    if (phoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call() + " " + phoneNumber);
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call() + " " + phoneNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var website in websites)
            {
                if (website.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine(smartPhone.Browsing() + $" {website}!");
                }
            }
        }
    }
}
