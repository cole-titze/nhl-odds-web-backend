using Entities.DbModels;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.GameOddsRepository
{
	public class GameOddsRepository : IGameOddsRepository
	{
        private readonly GameDbContext _dbContext;
        private const int MAX_GAMES = 15;
        public GameOddsRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            return await _dbContext.GameOdds.Where(x => (x.game.gameDate.Date >= dateRange.startDate && x.game.gameDate.Date <= dateRange.endDate))
                                        .OrderByDescending(d => d.game.gameDate)
                                        .Include(x => x.game).ThenInclude(x => x.awayTeam)
                                        .Include(x => x.game).ThenInclude(x => x.homeTeam)
                                        .Take(MAX_GAMES)
                                        .ToListAsync();
        }
    }
}

