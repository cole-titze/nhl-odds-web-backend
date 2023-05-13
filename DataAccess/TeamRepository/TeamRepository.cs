using Entities.Types;
using Microsoft.EntityFrameworkCore;
using DataAccess.TeamRepository.Mappers;
using Entities.DbModels;

namespace DataAccess.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly GameDbContext _dbContext;
        public TeamRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets all teams from the database
        /// </summary>
        /// <returns>Query to get all teams</returns>
        private IQueryable<DbTeam> GetAllTeamsQuery()
        {
            return _dbContext.Team.AsQueryable();
        }

        /// <summary>
        /// Gets all teams from the database
        /// </summary>
        /// <returns>List of teams</returns>
        public async Task<IEnumerable<TeamStats>> GetAllTeams()
        {
            var dbTeams = await GetAllTeamsQuery().ToListAsync();
            return DbTeamsToTeamStatsMapper.Map(dbTeams);
        }

        /// <summary>
        /// Gets a single team stats
        /// </summary>
        /// <param name="teamId">The team to get stats for</param>
        /// <returns>The team stats</returns>
        public async Task<TeamStats> GetTeam(int teamId)
        {
            var dbTeam = await GetAllTeamsQuery().Where(x => x.id == teamId).FirstAsync();
            return DbTeamToTeamStatsMapper.Map(dbTeam);
        }
    }
}
