using Entities.Types;

namespace DataAccess.GameOddsRepository
{
    public interface IGameOddsRepository
	{
        Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange);
        Task<IEnumerable<GameOdds>> GetTeamGameOdds(int teamId, int seasonStartYear);
    }
}

