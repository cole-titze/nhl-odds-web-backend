using System;
namespace Entities.Models
{
	public class LogLossData
	{
		public Dictionary<string, List<Odds>> OddsMap { get; set; } = new Dictionary<string, List<Odds>>();
		public List<int> TrueOutcomes { get; set; } = new List<int>();
	}
}

