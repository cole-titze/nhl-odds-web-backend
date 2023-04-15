using Entities.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Mappers;

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
        /// <returns>List of teams</returns>
        public async Task<IList<TeamStats>> GetAllTeams()
        {
            var dbTeams = await _dbContext.Team.ToListAsync();
            return DbTeamsToTeamsMapper.Map(dbTeams);
        }
    }
}
