using System;
using DataAccess.PredictedGameRepository;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.PredictedGameGetter
{
	public class PredictedGameGetter : IPredictedGameGetter
	{
        private readonly IPredictedGameRepository _predictedGameRepository;

        public PredictedGameGetter(IPredictedGameRepository predictedGameRepository)
		{
			_predictedGameRepository = predictedGameRepository;
		}

        public Task<IEnumerable<DbPredictedGame>> GetPredictedGamesInDateRange(DateRange dateRange)
        {
            return _predictedGameRepository.GetPredictedGamesInDateRange(dateRange);
        }
    }
}

