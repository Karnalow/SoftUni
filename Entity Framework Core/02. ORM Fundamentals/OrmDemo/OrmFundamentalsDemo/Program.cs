using System;
using System.Linq;

namespace OrmFundamentalsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();
            db.Towns.Add(new Town { Name = "Pernik" });
            db.SaveChanges();

            var departments = db.Employees
                .GroupBy(x => x.Department.Name)
                .Select(x => { Name = x.Key, Count = x.Count() })
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} => {department.Count}");
            }
        }
    }
}
