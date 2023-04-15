namespace Entities.Types
{
    public class GameOdds
	{
        public double vegasHomeOdds { get; set; }
        public double vegasAwayOdds { get; set; }
        public double modelHomeOdds { get; set; }
        public double modelAwayOdds { get; set; }
        public Game game { get; set; } = new Game();
    }
}

