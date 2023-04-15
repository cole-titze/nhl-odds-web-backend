using Entities.DbModels;
using Entities.Types;

namespace BusinessLogic.GameOddsGetter
{
    public interface IGameOddsGetter
    {
        Task<IEnumerable<GameOdds>> GetGameOddsInDateRange(DateRange dateRange);
    }
}