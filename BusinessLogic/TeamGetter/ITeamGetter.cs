using Entities.Models;

namespace BusinessLogic.TeamGetter
{
    public interface ITeamGetter
    {
        Task<IList<Team>> GetAllTeams();
        Task<IEnumerable<Team>> BuildLogLosses(int startYear);
    }
}
