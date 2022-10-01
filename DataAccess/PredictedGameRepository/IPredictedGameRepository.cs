using Entities.DbModels;
using Entities.Models;

namespace DataAccess.PredictedGameRepository
{
	public interface IPredictedGameRepository
	{
        Task<IEnumerable<DbPredictedGame>> GetFirstPredictedGamesOfYear(int year, int numberOfGames);
        Task<IEnumerable<DbPredictedGame>> GetPredictedGamesInDateRange(DateRange dateRange);
    }
}

