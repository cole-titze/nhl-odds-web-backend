using Entities.Models;

namespace BusinessLogic.TeamGetter
{
    public interface ITeamGetter
    {
        Task<IList<TeamStats>> GetAllTeams();
        Task<IEnumerable<TeamStats>> GetTeamLogLosses(int startYear);
    }
}
