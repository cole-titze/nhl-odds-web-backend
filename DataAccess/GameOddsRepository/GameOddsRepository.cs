using DataAccess.GameOddsRepository.Mappers;
using Entities.Types;
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
        /// <summary>
        /// Gets the game odds for all games within a given date range from the database
        /// </summary>
        /// <param name="dateRange">The date range to find games within</param>
        /// <returns>List of game odds</returns>
        public async Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange)
        {
            var dbGameOdds = await _dbContext.GameOdds.Where(x => (x.game.gameDate.Date >= dateRange.startDate && x.game.gameDate.Date <= dateRange.endDate))
                                        .OrderByDescending(d => d.game.gameDate)
                                        .Include(x => x.game).ThenInclude(x => x.awayTeam)
                                        .Include(x => x.game).ThenInclude(x => x.homeTeam)
                                        .Take(MAX_GAMES)
                                        .ToListAsync();

            return DbGameOddsToGameOddsMapper.Map(dbGameOdds);
        }
        /// <summary>
        /// Gets the game odds for a team during a year
        /// </summary>
        /// <param name="teamId">The team to get game odds for</param>
        /// <param name="seasonStartYear">The year to get games for</param>
        /// <returns>List of game odds</returns>
        public async Task<IEnumerable<GameOdds>> GetTeamGameOdds(int teamId, int seasonStartYear)
        {
            var dbGameOdds = await _dbContext.GameOdds.Where(x => (x.game.awayTeamId == teamId || x.game.homeTeamId == teamId) && x.game.seasonStartYear == seasonStartYear).ToListAsync();

            return DbGameOddsToGameOddsMapper.Map(dbGameOdds);
        }
    }
}

