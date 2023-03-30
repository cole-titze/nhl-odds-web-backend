using Entities.Models;

namespace DataAccess.TeamRepository
{
    public interface ITeamRepository
	{
        Task<IList<Team>> GetAllTeams();
    }
}

