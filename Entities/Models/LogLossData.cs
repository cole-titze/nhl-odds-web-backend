using System;
using Entities.DbModels;

namespace Entities.Models
{
	public class LogLossData
	{
		public Dictionary<string, List<Odds>> OddsMap { get; set; } = new Dictionary<string, List<Odds>>();
		public List<TEAM> TrueOutcomes { get; set; } = new List<TEAM>();
	}
}

