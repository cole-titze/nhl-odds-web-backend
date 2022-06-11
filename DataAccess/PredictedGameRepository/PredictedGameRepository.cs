using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PredictedGameRepository
{
	public class PredictedGameRepository : IPredictedGameRepository
	{
        private readonly PredictedGameDbContext _dbContext;
        public PredictedGameRepository(PredictedGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<DbPredictedGame>> GetPredictedGames()
        {
            return await _dbContext.PredictedGame.ToListAsync();
        }
	}
}

