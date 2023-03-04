using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02.FootballBetting.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(max)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Required]
        [DefaultValue(0.00)]
        public decimal Balance { get; set; }
    }
}
