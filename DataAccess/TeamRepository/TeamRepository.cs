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
        public async Task<IList<Team>> GetAllTeams()
        {
            var dbTeams = await _dbContext.Team.ToListAsync();
            return DbTeamsToTeamsMapper.Map(dbTeams);
        }
    }
}
