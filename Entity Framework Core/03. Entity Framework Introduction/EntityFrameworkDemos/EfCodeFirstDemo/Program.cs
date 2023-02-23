using EfCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.Migrate();
        }
    }
}
