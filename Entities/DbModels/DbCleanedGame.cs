using System;
namespace Entities.DbModels
{
	public class DbCleanedGame
	{
        public int id { get; set; }
        public int winner { get; set; }
        public bool hasBeenPlayed { get; set; }
    }
}

