using System;
using Entities.DbModels;

namespace BusinessLogic.PredictedGameGetter
{
    public interface IPredictedGameGetter
    {
        Task<IEnumerable<DbPredictedGame>> GetPredictedGames();
        Task<IEnumerable<DbPredictedGame>> GetPredictedGamesOnDate(DateTime day);
    }
}

