using System;
using Entities.Models;

namespace BusinessLogic.LogLoss
{
    public interface ILogLossCalculator
    {
        Task<IEnumerable<ModelLogLoss>> CalculateLogLossForYearAndNumberOfGames(int year, int numberOfGames);
    }
}

