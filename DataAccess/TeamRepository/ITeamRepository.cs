using Entities.Types;

namespace DataAccess.TeamRepository
{
    public interface ITeamRepository
	{
        Task<IEnumerable<TeamStats>> GetAllTeams();
    }
}

