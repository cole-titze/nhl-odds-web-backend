using DataAccess.GameOddsRepository;
using Entities.DbModels;
using Entities.Models;

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
        public Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return _gameOddsRepository.GetGameOddsInDateRange(dateRange);
        }
    }
}

