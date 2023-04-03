using DataAccess.GameOddsRepository;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogicTests.Fakes
{
    public class FakeGameOddsRepository : IGameOddsRepository
    {
        private IList<DbGameOdds> _predictedGames { get; set; } = new List<DbGameOdds>();
        public FakeGameOddsRepository(List<DbGameOdds> predictedGames)
        {
            _predictedGames = predictedGames;
        }
        public async Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return await Task.FromResult(_predictedGames.Where(x => (x.game.gameDate.Date >= dateRange.startDate && x.game.gameDate.Date <= dateRange.endDate)).ToList());
        }
    }
}

