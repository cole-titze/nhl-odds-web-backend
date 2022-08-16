using System;
using DataAccess.PredictedGameRepository;
using Entities.DbModels;

namespace BusinessLogic.PredictedGameGetter
{
	public class PredictedGameGetter : IPredictedGameGetter
	{
        private readonly IPredictedGameRepository _predictedGameRepository;

        public PredictedGameGetter(IPredictedGameRepository predictedGameRepository)
		{
			_predictedGameRepository = predictedGameRepository;
		}

        public Task<IEnumerable<DbPredictedGame>> GetPredictedGames()
        {
            return _predictedGameRepository.GetPredictedGames();
        }

        public Task<IEnumerable<DbPredictedGame>> GetPredictedGamesOnDate(DateTime day)
        {
            return _predictedGameRepository.GetPredictedGamesOnDate(day);
        }
    }
}

