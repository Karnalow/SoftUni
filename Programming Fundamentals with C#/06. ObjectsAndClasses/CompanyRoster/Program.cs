using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();

                string name = cmdArg[0];
                int salary = int.Parse(cmdArg[1]);
                string department = cmdArg[2];

                Employee employee = new Employee(name, salary, department);

                employees.Add(employee);
            }
        }
    }

    class Employee
    {
        public Employee(string name, int salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }
}
