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

        public Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return _gameOddsRepository.GetGameOddsInDateRange(dateRange);
        }
    }
}

