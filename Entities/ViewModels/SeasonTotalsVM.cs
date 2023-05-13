using System;
namespace Entities.ViewModels
{
	public class SeasonTotalsVM
	{
		public double vegasLogLoss { get; set; }
		public double modelLogLoss { get; set; }
		public int totalGameCount { get; set; }
		public int totalModelAccurateGameCount { get; set; }
        public int totalVegasAccurateGameCount { get; set; }
    }
}
