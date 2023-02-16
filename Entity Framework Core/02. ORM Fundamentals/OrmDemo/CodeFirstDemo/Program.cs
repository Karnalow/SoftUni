using CodeFirstDemo.Models;

namespace CodeFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
