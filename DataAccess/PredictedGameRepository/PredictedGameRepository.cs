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
            return await _dbContext.PredictedGame.Include(x => x.awayTeam)
                                                .Include(x => x.homeTeam)
                                                .Take(15)
                                                .ToListAsync();
        }
        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGamesOnDate(DateTime day)
        {
            return await _dbContext.PredictedGame.Where(x => x.gameDate.Date == day.Date).ToListAsync();
        }
        public async Task<IEnumerable<DbPredictedGame>> GetFirstPredictedGamesOfYear(int year, int numberOfGames)
        {
            return await _dbContext.PredictedGame.OrderByDescending(d => d.gameDate)
                                                    .Reverse()
                                                    .Take(numberOfGames)
                                                    .Where(x => x.gameDate.Year == year)
                                                    .ToListAsync();
        }
    }
}

