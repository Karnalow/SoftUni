using P02.FootballBetting.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace P02.FootballBetting.Data.Models
{
    public class Bet
    {
        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public PredictionType Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
