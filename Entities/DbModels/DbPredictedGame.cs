namespace Entities.DbModels
{
	public class DbPredictedGame
	{
        public int id { get; set; }
        public string homeTeamName { get; set; } = string.Empty;
        public string awayTeamName { get; set; } = string.Empty;
        public DateTime gameDate { get; set; }
        public double vegasHomeOdds { get; set; }
        public double vegasAwayOdds { get; set; }
        public double modelHomeOdds { get; set; }
        public double modelAwayOdds { get; set; }
    }
}

