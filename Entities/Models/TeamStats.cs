namespace Entities.Types
{
    public class TeamStats
    {
        public Team team { get; set; } = new Team();
        public double vegasLogLoss { get; set; }
        public double modelLogLoss { get; set; }
    }
}
