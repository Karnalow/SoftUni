using System.ComponentModel.DataAnnotations;

namespace P02.FootballBetting.Data.Models
{
    public class Positon
    {
        public Positon()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int PositionId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
