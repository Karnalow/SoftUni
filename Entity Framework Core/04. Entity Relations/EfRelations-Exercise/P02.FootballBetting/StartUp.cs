using P02.FootballBetting.Data;

namespace P02.FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}