using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;

namespace RealEstates.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            db.Districts.Add(new District { Name = "Bracigovo"});
            db.SaveChanges();
        }
    }
}