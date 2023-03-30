namespace Entities.DbModels
{
    public class DbCleanedGame
	{
        public int id { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
    }
    public enum TEAM
    {
        home = 0,
        away = 1
    }
}

