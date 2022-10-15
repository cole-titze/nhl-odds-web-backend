using System;
using DataAccess.PredictedGameRepository;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogicTests.Fakes
{
    public class FakePredictedGameRepository : IPredictedGameRepository
    {
        private IList<DbPredictedGame> _predictedGames { get; set; } = new List<DbPredictedGame>();
        public FakePredictedGameRepository(List<DbPredictedGame> predictedGames)
        {
            _predictedGames = predictedGames;
        }
        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGamesInDateRange(DateRange dateRange)
        {
            return await Task.FromResult(_predictedGames.Where(x => (x.gameDate.Date >= dateRange.startDate && x.gameDate.Date <= dateRange.endDate)).ToList());
        }
    }
}

