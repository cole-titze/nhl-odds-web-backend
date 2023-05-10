namespace Entities.Types
{
    public class TeamStats
    {
        public Team team { get; set; } = new Team();
        public double vegasLogLoss { get; set; }
        public double modelLogLoss { get; set; }
        public IEnumerable<GameOdds> gameOdds { get; set; } = new List<GameOdds>();
    }
}
