using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.GameOddsGetter
{
    public interface IGameOddsGetter
    {
        Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange);
    }
}