using DataAccess.GameOddsRepository;
using Entities.Types;

namespace BusinessLogicTests.Fakes
{
    public class FakeGameOddsRepository : IGameOddsRepository
    {
        private IList<GameOdds> _predictedGames { get; set; } = new List<GameOdds>();
        public FakeGameOddsRepository(List<GameOdds> predictedGames)
        {
            _predictedGames = predictedGames;
        }
        public async Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return await Task.FromResult(_predictedGames.Where(x => (x.game.gameDate.Date >= dateRange.startDate && x.game.gameDate.Date <= dateRange.endDate)).ToList());
        }

        public Task<IEnumerable<GameOdds>> GetTeamGameOdds(int teamId, int seasonStartYear)
        {
            throw new NotImplementedException();
        }
    }
}

