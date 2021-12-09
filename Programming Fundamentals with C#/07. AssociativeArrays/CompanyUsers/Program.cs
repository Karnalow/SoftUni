using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string[] input =
                Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                string companyName = input[0];
                string employeeId = input[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }

                input =
                Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var companie in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{companie.Key}");

                foreach (var employee in companie.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
