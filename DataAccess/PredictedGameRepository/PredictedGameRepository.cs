using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PredictedGameRepository
{
	public class PredictedGameRepository : IPredictedGameRepository
	{
        private readonly PredictedGameDbContext _dbContext;
        public PredictedGameRepository(PredictedGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGames()
        {
            return await _dbContext.PredictedGame.Take(15)
                                                .Include(x => x.awayTeam)
                                                .Include(x => x.homeTeam)
                                                .Include(x => x.cleanedGame)
                                                .ToListAsync();
        }
        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGamesOnDate(DateTime day)
        {
            return await _dbContext.PredictedGame.Where(x => x.gameDate.Date == day.Date)
                                                .Include(x => x.cleanedGame)
                                                .ToListAsync();
        }
        // Get all valid predicted games that have been played
        public async Task<IEnumerable<DbPredictedGame>> GetFirstPredictedGamesOfYear(int year, int numberOfGames)
        {
            return await _dbContext.PredictedGame.OrderByDescending(d => d.gameDate)
                                                    .Reverse()
                                                    .Take(numberOfGames)
                                                    .Where(x => (x.bet365OpeningVegasHomeOdds != -1 || x.bet365OpeningVegasAwayOdds != -1))
                                                    .Where(x => (x.bet365ClosingVegasHomeOdds != -1 || x.bet365ClosingVegasAwayOdds != -1))
                                                    .Where(x => (x.bovadaOpeningVegasHomeOdds != -1 || x.bovadaOpeningVegasAwayOdds != -1))
                                                    .Where(x => (x.bovadaClosingVegasHomeOdds != -1 || x.bovadaClosingVegasAwayOdds != -1))
                                                    .Where(x => (x.pinnacleOpeningVegasHomeOdds != -1 || x.pinnacleOpeningVegasAwayOdds != -1))
                                                    .Where(x => (x.pinnacleClosingVegasHomeOdds != -1 || x.pinnacleClosingVegasAwayOdds != -1))
                                                    .Where(x => (x.myBookieOpeningVegasHomeOdds != -1 || x.myBookieOpeningVegasAwayOdds != -1))
                                                    .Where(x => (x.myBookieClosingVegasHomeOdds != -1 || x.myBookieClosingVegasAwayOdds != -1))
                                                    .Where(x => (x.betOnlineOpeningVegasHomeOdds != -1 || x.betOnlineOpeningVegasAwayOdds != -1))
                                                    .Where(x => (x.betOnlineClosingVegasHomeOdds != -1 || x.betOnlineClosingVegasHomeOdds != -1))
                                                    .Where(x => (x.bet365OpeningVegasHomeOdds != 0 || x.bet365OpeningVegasAwayOdds != 0))
                                                    .Where(x => (x.bet365ClosingVegasHomeOdds != 0 || x.bet365ClosingVegasAwayOdds != 0))
                                                    .Where(x => (x.bovadaOpeningVegasHomeOdds != 0 || x.bovadaOpeningVegasAwayOdds != 0))
                                                    .Where(x => (x.bovadaClosingVegasHomeOdds != 0 || x.bovadaClosingVegasAwayOdds != 0))
                                                    .Where(x => (x.pinnacleOpeningVegasHomeOdds != 0 || x.pinnacleOpeningVegasAwayOdds != 0))
                                                    .Where(x => (x.pinnacleClosingVegasHomeOdds != 0 || x.pinnacleClosingVegasAwayOdds != 0))
                                                    .Where(x => (x.myBookieOpeningVegasHomeOdds != 0 || x.myBookieOpeningVegasAwayOdds != 0))
                                                    .Where(x => (x.myBookieClosingVegasHomeOdds != 0 || x.myBookieClosingVegasAwayOdds != 0))
                                                    .Where(x => (x.betOnlineOpeningVegasHomeOdds != 0 || x.betOnlineOpeningVegasAwayOdds != 0))
                                                    .Where(x => (x.betOnlineClosingVegasHomeOdds != 0 || x.betOnlineClosingVegasHomeOdds != 0))
                                                    .Include(x => x.cleanedGame )
                                                    .Where(x => x.cleanedGame.hasBeenPlayed == true)
                                                    .ToListAsync();
        }
    }
}

