using System;
namespace Entities.DbModels
{
	public class DbCleanedGame
	{
        public int id { get; set; }
        public WINNER winner { get; set; }
        public bool hasBeenPlayed { get; set; }
    }
    public enum WINNER
    {
        home = 0,
        away = 1
    }
}

