using Entities.Types;

namespace BusinessLogic.TeamGetter
{
    public interface ITeamGetter
    {
        Task<IEnumerable<TeamStats>> GetTeamStats(int startYear);
    }
}
