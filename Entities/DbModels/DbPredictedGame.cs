using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DbModels
{
    public class DbPredictedGame
    {
        public int id { get; set; }
        public int homeTeamId { get; set; }
        public int awayTeamId { get; set; }
        public DateTime gameDate { get; set; }
        public double vegasHomeOdds { get; set; }
        public double vegasAwayOdds { get; set; }
        public double modelHomeOdds { get; set; }
        public double modelAwayOdds { get; set; }

        [ForeignKey("homeTeamId")]
        public DbTeam homeTeam { get; set; }
        [ForeignKey("awayTeamId")]
        public DbTeam awayTeam { get; set; }
    }
}

