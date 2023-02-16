using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=CodeFirstDemo");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<News> News { get; set; }
    }
}
