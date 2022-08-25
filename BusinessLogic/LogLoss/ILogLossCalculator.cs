using System;
using Entities.Models;

namespace BusinessLogic.LogLoss
{
    public interface ILogLossCalculator
    {
        Task<IEnumerable<ModelLogLoss>> CalculateLogLossesForYearAndNumberOfGames(int year, int numberOfGames);
    }
}

