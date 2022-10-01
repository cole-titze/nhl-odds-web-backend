using System;
using Entities.DbModels;
using Entities.Models;

namespace Entities.ViewModels
{
	public class PredictedGameViewModel
	{
        public int id { get; set; }
        public DateTime gameDate { get; set; }
        public TeamViewModel? homeTeam { get; set; }
        public TeamViewModel? awayTeam { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
    }
}

