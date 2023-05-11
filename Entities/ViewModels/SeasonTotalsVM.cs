using System;
namespace Entities.ViewModels
{
	public class SeasonTotalsVM
	{
		public double vegasLogLossTotal { get; set; }
		public double modelLogLossTotal { get; set; }
		public int totalGameCount { get; set; }
		public int totalModelAccurateGameCount { get; set; }
        public int totalVegasAccurateGameCount { get; set; }
    }
}
