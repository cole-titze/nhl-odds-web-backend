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
        /// <summary>
        /// Queryable to get all db log losses for a given season
        /// </summary>
        /// <param name="seasonStartYear">The season start year</param>
        /// <returns>Queryable that gets all dbLogLosses for a season</returns>
        private IQueryable<DbLogLoss> GetAllDbLogLossesForSeasonQuery(int seasonStartYear)
        {
            return _dbContext.LogLossGame.Include(x => x.game)
                                         .Where(x => x.game.seasonStartYear == seasonStartYear)
                                         .OrderByDescending(d => d.game.gameDate)
                                         .AsQueryable();
        }

        /// <summary>
        /// Gets log losses for all games of a given season
        /// </summary>
        /// <param name="seasonStartYear">The year to get the log losses of</param>
        /// <returns>List log losses</returns>
        public async Task<IEnumerable<DbLogLoss>> GetAllLogLossesForSeason(int seasonStartYear)
        {
            var dbLogLosses = await GetAllDbLogLossesForSeasonQuery(seasonStartYear).ToListAsync();
            return dbLogLosses;
        }

        /// <summary>
        /// Gets log losses for all games for a given team and season
        /// </summary>
        /// <param name="teamId">The team to get log losses for</param>
        /// <param name="seasonStartYear">The season to get log losses for</param>
        /// <returns>List of log losses for the given team</returns>
        public async Task<IEnumerable<DbLogLoss>> GetTeamLogLossesForSeason(int teamId, int seasonStartYear)
        {
            var dbLogLosses = await GetAllDbLogLossesForSeasonQuery(seasonStartYear)
                                        .Where(x => x.game.homeTeamId == teamId || x.game.awayTeamId == teamId)
                                        .ToListAsync();
            return dbLogLosses;
        }
    }
}

