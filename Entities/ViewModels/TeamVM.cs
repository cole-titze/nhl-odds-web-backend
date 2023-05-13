namespace Entities.ViewModels
{
    public class TeamVM
	{
        public int id { get; set; }
        public string locationName { get; set; } = string.Empty;
        public string teamName { get; set; } = string.Empty;
        public string logoUri { get; set; } = string.Empty;
        public double vegasLogLoss { get; set; }
        public double modelLogLoss { get; set; }
        public int totalGameCount { get; set; }
        public int totalModelAccurateGameCount { get; set; }
        public int totalVegasAccurateGameCount { get; set; }
    }
}
