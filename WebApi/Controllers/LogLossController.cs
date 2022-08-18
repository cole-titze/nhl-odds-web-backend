using System;
using BusinessLogic.LogLoss;
using BusinessLogic.PredictedGameGetter;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogLossController
	{
        private readonly ILogger<PredictedGameController> _logger;
        private readonly ILogLossCalculator _logLossCalculator;
        public LogLossController(ILogger<PredictedGameController> logger, IPredictedGameGetter predictedGameBL, ILogLossCalculator logLossBL)
        {
            _logger = logger;
            _logLossCalculator = logLossBL;
        }
        /// <summary>
        /// Returns the log loss of the first number of games passed in, for a given year
        /// Example Call: http://localhost:32616/api/logloss/GetLogLossesOfYearByNumberOfGames?year=2021&numberofgames=100
        /// </summary>
        /// <returns>List of ModelLogLosses</returns>
        [HttpGet]
        public async Task<IResult> GetLogLossesOfYearByNumberOfGames(int year, int numberOfGames)
        {
            var logLosses = await _logLossCalculator.CalculateLogLossesForYearAndNumberOfGames(year, numberOfGames);
            return Results.Ok(logLosses);
        }
    }
}

