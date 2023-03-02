using EfCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.ModelBuilding
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => new { e.Id, e.Egn });

            builder.Property(e => e.FirstName)
                .IsRequired(); // NOT NULL

            builder.Property(e => e.FirstName)
            .HasMaxLength(20);

            builder.Property(e => e.LastName)
                .IsRequired()  // NOT NULL
                .HasMaxLength(100);

            builder.Ignore(e => e.FullName);

            builder.Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn")
                .HasColumnType("date");

            builder.HasOne(x => x.Department) //required
                .WithMany(x => x.Employees) //optional (inverse)
                .HasForeignKey(x => x.DepartmentId) //db colum name (optional)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
