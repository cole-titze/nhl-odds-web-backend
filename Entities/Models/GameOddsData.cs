using System;
using Entities.DbModels;

namespace Entities.Models
{
	public class GameOddsData
	{
		public Dictionary<string, List<Odds>> OddsMap { get; set; } = new Dictionary<string, List<Odds>>();
		public List<Odds> homeModelOdds { get; set; } = new List<Odds>();
		public List<WINNER> TrueOutcomes { get; set; } = new List<WINNER>();
	}
}

