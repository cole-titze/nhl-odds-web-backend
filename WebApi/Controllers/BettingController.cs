using System;
using BusinessLogic.Betting;
using BusinessLogic.PredictedGameGetter;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BettingController
    {
        private readonly ILogger<PredictedGameController> _logger;
        private readonly IBettingCalculator _bettingCalculator;
        public BettingController(ILogger<PredictedGameController> logger, IBettingCalculator bettingCalculator)
        {
            _logger = logger;
            _bettingCalculator = bettingCalculator;
        }
        /// <summary>
        /// Returns the betting results of the first number of games passed in, for a given year
        /// Example Call: http://localhost:32616/api/betting/GetBettingResultOfYearByNumberOfGames?year=2021&numberofgames=10&betAmount=100
        /// </summary>
        /// <returns>List of ModelLogLosses</returns>
        [HttpGet]
        public async Task<IResult> GetBettingResultOfYearByNumberOfGames(int year, int numberOfGames, double betAmount)
        {
            var betResults = await _bettingCalculator.CalculateBetOutcomes(year, numberOfGames, betAmount);
            return Results.Ok(betResults);
        }
        /// <summary>
        /// Returns the betting results of the first number of games passed in, for a given year. Given an odds difference strategy
        /// Example Call: http://localhost:32616/api/betting/GetBettingResultOfYearByNumberOfGames_OddsDifference?year=2021&numberofgames=10&betAmount=100
        /// </summary>
        /// <returns>List of ModelLogLosses</returns>
        [HttpGet]
        public async Task<IResult> GetBettingResultOfYearByNumberOfGames_OddsDifference(int year, int numberOfGames, double betAmount)
        {
            var betResults = await _bettingCalculator.CalculateBetOutcomesOddsDifference(year, numberOfGames, betAmount);
            return Results.Ok(betResults);
        }
    }
}