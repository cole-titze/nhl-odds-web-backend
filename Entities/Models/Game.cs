using Entities.DbModels;

namespace Entities.Types
{
    public class Game
	{
        public int id { get; set; }
        public DateTime gameDate { get; set; }
        public int homeGoals { get; set; }
        public int awayGoals { get; set; }
        public int seasonStartYear { get; set; }
        public TEAM winner { get; set; }
        public bool hasBeenPlayed { get; set; }
        public Team homeTeam { get; set; } = new Team();
        public Team awayTeam { get; set; } = new Team();

        /// <summary>
        /// Gets if the given team won or not. If the game has not been played returns 0
        /// </summary>
        /// <param name="teamId">The team to check</param>
        /// <returns>1 if the team won, otherwise 0</returns>
        public int IsWin(int teamId)
        {
            if (!hasBeenPlayed)
                return 0;

            if ((homeTeam.id == teamId && winner == TEAM.home) || (awayTeam.id == teamId && winner == TEAM.away))
                return 1;

            return 0;
        }
        /// <summary>
        /// Gets if the given team loss or not. If the game has not been played returns 0
        /// </summary>
        /// <param name="teamId">The team to check</param>
        /// <returns>1 if the team won, otherwise 0</returns>
        public int IsLoss(int teamId)
        {
            if (!hasBeenPlayed)
                return 0;

            if ((homeTeam.id == teamId && winner != TEAM.home) || (awayTeam.id == teamId && winner != TEAM.away))
                return 1;

            return 0;
        }
    }
}

