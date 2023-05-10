using DataAccess.GameOddsRepository;
using Entities.Types;

namespace BusinessLogic.GameOddsGetter
{
    public class GameOddsGetter : IGameOddsGetter
	{
        private readonly IGameOddsRepository _gameOddsRepository;

        public GameOddsGetter(IGameOddsRepository predictedGameRepository)
		{
			_gameOddsRepository = predictedGameRepository;
		}
        /// <summary>
        /// Gets the game odds for all games within a given date range
        /// </summary>
        /// <param name="dateRange">The date range to find games within</param>
        /// <returns>List of game odds</returns>
        public async Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return await _gameOddsRepository.GetGameOddsInDateRange(dateRange);
        }
        /// <summary>
        /// Gets the game odds for all teams
        /// </summary>
        /// <param name="teams">The teams to get odds for</param>
        /// <param name="seasonStartYear">The year to get games for</param>
        /// <returns>List of game odds</returns>
        public async Task<IEnumerable<TeamStats>> BuildTeamsGameOdds(IEnumerable<TeamStats> teams, int seasonStartYear)
        {
            foreach(var team in teams)
            {
                team.gameOdds = await GetTeamGameOdds(team.team.id, seasonStartYear);
            }

            return teams;
        }
        /// <summary>
        /// Gets the game odds for a team during a year
        /// </summary>
        /// <param name="teamId">The team to get game odds for</param>
        /// <param name="seasonStartYear">The year to get games for</param>
        /// <returns>List of game odds</returns>
        public async Task<IEnumerable<GameOdds>> GetTeamGameOdds(int teamId, int seasonStartYear)
        {
            return await _gameOddsRepository.GetTeamGameOdds(teamId, seasonStartYear);
        }
    }
}

