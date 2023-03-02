using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreDemo.Models
{
    [Table("People", Schema = "company")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Egn { get; set; }

        [Required]
        [Column("FN")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        [Column("StartedOn", TypeName = "date")]
        public DateTime? StartWorkDate { get; set; }

        public decimal? Salary { get; set; }

        //Optional
        public int DepartmentId { get; set; }

        //Required property
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public Department Department { get; set; }
    }
}
