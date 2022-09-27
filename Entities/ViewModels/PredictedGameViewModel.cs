using System;
using Entities.Models;

namespace Entities.ViewModels
{
	public class PredictedGameViewModel
	{
        public int id { get; set; }
        public DateTime gameDate { get; set; }
        public Team? homeTeam { get; set; }
        public Team? awayTeam { get; set; }
    }
}

