using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02.FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.GameStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGolas { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Column(TypeName = "decimal")]
        public double HomeTeamBetRate { get; set; }

        [Column(TypeName = "decimal")]
        public double AwayTeamBetRate { get; set; }

        [Column(TypeName = "decimal")]
        public double DrawBetRate { get; set; }

        [Required]
        public string Result { get; set; }

        public virtual ICollection<PlayerStatistic> GameStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
