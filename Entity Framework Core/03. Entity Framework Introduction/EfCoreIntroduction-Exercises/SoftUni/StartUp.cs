using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();

            string employeesFullInfo = GetEmployeesFullInfo(db);
            string employeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(db);
            string employeesFromResearchAndDevelopment = GetEmployeesFromResearchAndDevelopment(db);
            string employeesWithNewAddreses = AddNewAddressToEmployee(db);
            string employeesAndProjects = GetEmployeesInPeriod(db);
            string addressesByTown = GetAddressesByTown(db);
            string employee147 = GetEmployee147(db);
            string departmentsWithMoreThan5Employees = GetDepartmentsWithMoreThan5Employees(db);
            string latest10Projects = GetLatestProjects(db);
            string increaseSalaries = IncreaseSalaries(db);

            //Console.WriteLine(employeesInfo);
            //Console.WriteLine(employeesWithSalaryOver50000);
            //Console.WriteLine(employeesFromResearchAndDevelopment);
            //Console.WriteLine(employeesWithNewAddreses);
            //Console.WriteLine(employeesAndProjects);
            //Console.WriteLine(addressesByTown);
            //Console.WriteLine(employee147);
            //Console.WriteLine(departmentsWithMoreThan5Employees);
            //Console.WriteLine(latest10Projects);
            //Console.WriteLine(increaseSalaries);
        }

        

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            List<string> departmentsNames = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employeesToIncrease = context.Employees
                .Where(e => departmentsNames.Contains(e.Department.Name));

            foreach (var employee in employeesToIncrease)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employees = employeesToIncrease.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            }).OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                }).OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate);
            }


            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments.Select(d => new
            {
                EmployeesCount = d.Employees.Count,
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                }).OrderBy(x => x.FirstName)
                  .ThenBy(x => x.LastName)
                  .ToList()
            }).Where(d => d.EmployeesCount > 5)
              .OrderBy(d => d.EmployeesCount)
              .ThenBy(d => d.Name)
              .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                .Select(p => new
                {
                    ProjectName = p.Project.Name
                    
                }).OrderBy(e => e.ProjectName)
                  .ToList()
            }).Where(e => e.EmployeeId == 147)
              .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine(project.ProjectName);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses.Select(x => new
            {
                x.AddressText,
                TownName = x.Town.Name,
                EmployeesCount = x.Employees.Count
            }).OrderByDescending(x => x.EmployeesCount)
              .ThenBy(x => x.TownName)
              .ThenBy(x => x.AddressText)
              .Take(10)
              .ToList();

            foreach ( var address in addresses) 
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(x => x.EmployeesProjects
            .Any(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(x => new
            {
                x.FirstName,
                x.LastName,
                ManagerFirstName = x.Manager.FirstName,
                ManagerLastName = x.Manager.LastName,
                Projects = x.EmployeesProjects
                .Select(e => new
                {
                    ProjectName = e.Project.Name,
                    StartDate = e.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = e.Project.EndDate.HasValue
                    ?e.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                }).ToList()
            });

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Addresses()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees.First(x => x.LastName == "Nakov");

            employee.Address = newAddress;
            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText).ToList();

            foreach ( var address in addresses ) 
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.Salary,
                x.Department
            }).Where(x => x.Department.Name == "Research and Development")
              .OrderBy(x => x.Salary)
              .ThenByDescending(x => x.FirstName)
              .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();   
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.Salary
            }).OrderBy(x => x.FirstName).ToList();

            foreach (var employee in employees)
            {
                if (employee.Salary > 50000)
                {
                    sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInfo(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Select(x => new
            {
                Id = x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            }).OrderBy(x => x.Id).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
