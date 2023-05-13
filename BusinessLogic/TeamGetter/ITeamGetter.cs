using Entities.Types;

namespace BusinessLogic.TeamGetter
{
    public interface ITeamGetter
    {
        Task<IEnumerable<TeamStats>> GetAllTeamsStats(int startYear);
        Task<TeamStats> GetTeamStats(int teamId, int startYear);

    }
}
