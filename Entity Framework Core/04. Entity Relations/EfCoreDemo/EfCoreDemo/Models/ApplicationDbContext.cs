using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EfCoreDemo;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => new { e.Id, e.Egn});

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsRequired(); // NOT NULL

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired()  // NOT NULL
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>()
                .Ignore(e => e.FullName);

            modelBuilder.Entity<Employee>()
                .Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn")
                .HasColumnType("date");

            base.OnModelCreating(modelBuilder);
        }
    }
}
