using EfCoreDemo.Models;
using System;

namespace EfCoreDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { Name = "HR" };

            for (int i = 0; i < 10; i++)
            {
                db.Employees.Add(new Employee
                {
                    Egn = "044421342" + i,
                    FirstName = "Ivan_" + i,
                    LastName = "Karnalov",
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 1000 + i,
                    Department = department
                });
            }

            db.SaveChanges();
        }
    }
}
