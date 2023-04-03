using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DbModels
{
    public class DbGame
	{
		public int id { get; set; }
        public DateTime gameDate { get; set; }
        public int homeTeamId { get; set; }
        public int awayTeamId { get; set; }
        public int homeGoals { get; set; }
		public int awayGoals { get; set; }
        public int seasonStartYear { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
        [ForeignKey("homeTeamId")]
        public DbTeam homeTeam { get; set; } = new DbTeam();
        [ForeignKey("awayTeamId")]
        public DbTeam awayTeam { get; set; } = new DbTeam();
    }
    public enum TEAM
    {
        home = 0,
        away = 1
    }
}

