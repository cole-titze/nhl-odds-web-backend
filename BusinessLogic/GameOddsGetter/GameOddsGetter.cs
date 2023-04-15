using DataAccess.GameOddsRepository;
using Entities.DbModels;
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
    }
}

