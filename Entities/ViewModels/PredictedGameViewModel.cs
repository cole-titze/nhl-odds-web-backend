using System;
using Entities.DbModels;
using Entities.Models;

namespace Entities.ViewModels
{
	public class PredictedGameViewModel
	{
        public int id { get; set; }
        public DateTime gameDate { get; set; }
        public MatchupTeamViewModel? homeTeam { get; set; }
        public MatchupTeamViewModel? awayTeam { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
    }
}

