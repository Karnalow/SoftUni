using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Ado.NetDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni;TrustServerCertificate=true"))
            {
                connection.Open();
                var sqlCommand = new SqlCommand
                    ("SELECT FirstName, LastName, Salary, d.Name " +
                    "FROM Employees e " +
                    "JOIN Departments d ON e.DepartmentId = d.DepartmentId ", connection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                while (sqlDataReader.Read())
                {
                    var employee = new Employee()
                    {
                        DepartmentName = sqlDataReader["Name"] as string,
                        FirstName = sqlDataReader["FirstName"] as string,
                        LastName = sqlDataReader["LastName"] as string,
                        Salary = sqlDataReader["Salary"] as decimal?
                    };

                    employees.Add(employee);
                }

                Console.WriteLine(employees.Count);
            }
        }
    }

    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal? Salary { get; set; }

        public string DepartmentName { get; set; }
    }
}
