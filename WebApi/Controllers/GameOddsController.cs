using BusinessLogic.GameOddsGetter;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameOddsController
	{
        private readonly ILogger<GameOddsController> _logger;
        private readonly IGameOddsGetter _gameOddsGetter;

        public GameOddsController(ILogger<GameOddsController> logger, IGameOddsGetter predictedGameBL)
        {
            _logger = logger;
            _gameOddsGetter = predictedGameBL;
        }
        /// <summary>
        /// Gets up to 15 games within the given start and end dates.
        /// </summary>
        /// <param name="startDate">Start Date for search</param>
        /// <param name="endDate">End Date for search</param>
        /// <returns>List of PredictedGameView Models that fall within the dates</returns>
        [HttpGet]
        public async Task<IResult> GetGameOddsInDateRange(DateTime startDate, DateTime endDate)
        {
            var utcDateRange = new DateRange
            {
                startDate = startDate.ToUniversalTime(),
                endDate = endDate.ToUniversalTime()
            };
            var predictedGames = await _gameOddsGetter.GetGameOddsInDateRange(utcDateRange);
            var predictedGamesVM = PredictedGamesToViewModelsMapper.Map(predictedGames);
            return Results.Ok(predictedGamesVM);
        }
    }
}
