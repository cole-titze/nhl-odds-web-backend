using System;
using Entities.Models;

namespace BusinessLogic.Betting
{
    public class BettingCalculator : IBettingCalculator
    {
        public Task<ModelBetResult> CalculateBetOutcomes(int year, int numberOfGames, decimal betAmount)
        {
            throw new NotImplementedException();
        }
    }
}

