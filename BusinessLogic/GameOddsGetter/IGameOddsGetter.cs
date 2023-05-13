using Entities.Types;

namespace BusinessLogic.GameOddsGetter
{
    public interface IGameOddsGetter
    {
        Task<IEnumerable<TeamStats>> BuildTeamsGameOdds(IEnumerable<TeamStats> teams, int seasonStartYear);
        Task<TeamStats> BuildTeamGameOdds(TeamStats team, int seasonStartYear);
        Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange);
        Task<IEnumerable<GameOdds>> GetTeamGameOdds(int teamId, int seasonStartYear);
    }
}