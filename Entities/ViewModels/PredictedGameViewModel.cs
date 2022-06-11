using System;
namespace Entities.ViewModels
{
	public class PredictedGameViewModel
	{
        public string homeTeamName { get; set; } = string.Empty;
        public string awayTeamName { get; set; } = string.Empty;
        public DateTime gameDate { get; set; }
        public double vegasHomeOdds { get; set; }
        public double vegasAwayOdds { get; set; }
        public double modelHomeOdds { get; set; }
        public double modelAwayOdds { get; set; }
        // Eventually add Should I bet based on vegas and model odds
    }
}

