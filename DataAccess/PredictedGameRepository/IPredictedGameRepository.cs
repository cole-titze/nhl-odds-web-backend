using Entities.DbModels;
namespace DataAccess.PredictedGameRepository
{
	public interface IPredictedGameRepository
	{
		Task<IEnumerable<DbPredictedGame>> GetPredictedGames();
        Task<IEnumerable<DbPredictedGame>> GetPredictedGamesOnDate(DateTime day);
        Task<IEnumerable<DbPredictedGame>> GetFirstPredictedGamesOfYear(int year, int numberOfGames);
    }
}

