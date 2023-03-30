namespace Entities.DbModels
{
    public class DbGame
	{
		public int id { get; set; }
        public int homeTeamId { get; set; }
        public int awayTeamId { get; set; }
        public int homeGoals { get; set; }
		public int awayGoals { get; set; }
        public int seasonStartYear { get; set; }
    }
}

