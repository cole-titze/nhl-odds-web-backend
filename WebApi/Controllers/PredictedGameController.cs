using BusinessLogic.LogLoss;
using BusinessLogic.PredictedGameGetter;
using DataAccess.PredictedGameRepository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PredictedGameController
	{
        private readonly ILogger<PredictedGameController> _logger;
        private readonly IPredictedGameGetter _predictedGameGetter;

        public PredictedGameController(ILogger<PredictedGameController> logger, IPredictedGameGetter predictedGameBL)
        {
            _logger = logger;
            _predictedGameGetter = predictedGameBL;
        }
        /// <summary>
        /// Gets up to 25 games within the given start and end dates.
        /// </summary>
        /// <param name="startDate">Start Date for search</param>
        /// <param name="endDate">End Date for search</param>
        /// <returns>List of PredictedGameView Models that fall within the dates</returns>
        [HttpGet]
        public async Task<IResult> GetPredictedGamesInDateRange(DateTime startDate, DateTime endDate)
        {
            var utcDateRange = new DateRange
            {
                startDate = startDate.ToUniversalTime(),
                endDate = endDate.ToUniversalTime()
            };
            var predictedGames = await _predictedGameGetter.GetPredictedGamesInDateRange(utcDateRange);
            var predictedGamesVM = PredictedGamesToViewModelsMapper.Map(predictedGames);
            return Results.Ok(predictedGamesVM);
        }
    }
}
