using Entities.DbModels;

namespace Entities.Types
{
    public class Game
	{
        public int id { get; set; }
        public DateTime gameDate { get; set; }
        public int homeGoals { get; set; }
        public int awayGoals { get; set; }
        public int seasonStartYear { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
        public Team homeTeam { get; set; } = new Team();
        public Team awayTeam { get; set; } = new Team();
    }
}

