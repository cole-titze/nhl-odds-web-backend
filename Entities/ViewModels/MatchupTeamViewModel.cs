using Entities.DbModels;

namespace Entities.ViewModels
{
    public class MatchupTeamViewModel
	{
        public int id { get; set; }
        public string locationName { get; set; } = string.Empty;
        public string teamName { get; set; } = string.Empty;
        public string logoUri { get; set; } = string.Empty;
        public double modelOdds { get; set; }
        public double vegasOdds { get; set; }
        public int goals { get; set; }
        public TEAM team { get; set; }
    }
}
