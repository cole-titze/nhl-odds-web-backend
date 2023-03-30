using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.PredictedGameGetter
{
    public interface IPredictedGameGetter
    {
        Task<IEnumerable<DbPredictedGame>> GetPredictedGamesInDateRange(DateRange dateRange);
    }
}