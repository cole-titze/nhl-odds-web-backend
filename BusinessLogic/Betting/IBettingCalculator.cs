using System;
using Entities.Models;

namespace BusinessLogic.Betting
{
    public interface IBettingCalculator
    {
        Task<IEnumerable<ModelBetResult>> CalculateBetOutcomes(int year, int numberOfGames, decimal betAmount);
    }
}

