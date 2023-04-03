using Entities.DbModels;
using Entities.Models;

namespace DataAccess.GameOddsRepository
{
	public interface IGameOddsRepository
	{
        Task<IEnumerable<DbGameOdds>> GetGameOddsInDateRange(DateRange dateRange);
    }
}

