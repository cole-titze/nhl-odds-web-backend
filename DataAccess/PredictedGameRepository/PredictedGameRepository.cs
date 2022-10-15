using Entities.DbModels;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PredictedGameRepository
{
	public class PredictedGameRepository : IPredictedGameRepository
	{
        private readonly GameDbContext _dbContext;
        private const int MAX_GAMES = 15;
        public PredictedGameRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGamesInDateRange(DateRange dateRange)
        {
            return await _dbContext.PredictedGame.Where(x => (x.gameDate.Date >= dateRange.startDate && x.gameDate.Date <= dateRange.endDate))
                                        .OrderByDescending(d => d.gameDate)
                                        .Include(x => x.cleanedGame)
                                        .Include(x => x.awayTeam)
                                        .Include(x => x.homeTeam)
                                        .Include(x => x.game)
                                        .Take(MAX_GAMES)
                                        .ToListAsync();
        }
    }
}

