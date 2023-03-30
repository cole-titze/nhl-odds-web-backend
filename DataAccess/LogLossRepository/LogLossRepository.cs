using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.LogLossRepository
{
    public class LogLossRepository : ILogLossRepository
	{
        private readonly GameDbContext _dbContext;
        public LogLossRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<DbLogLoss>> GetAllLogLossesForSeason(int seasonStartYear)
        {
            var dbTeams = await _dbContext.LogLossGame.Include(x => x.game)
                                                        .Where(x => x.game.seasonStartYear == seasonStartYear)
                                                        .ToListAsync();
            return dbTeams;
        }
    }
}

