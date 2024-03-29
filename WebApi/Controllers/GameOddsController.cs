﻿using BusinessLogic.GameOddsGetter;
using Entities.Types;
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
        /// Gets up to 15 games within the given start and end dates. Uses central standard time of games for the dates
        /// </summary>
        /// <param name="startDate">Start Date for search</param>
        /// <param name="endDate">End Date for search</param>
        /// <returns>List of PredictedGameView Models that fall within the dates</returns>
        [HttpGet]
        public async Task<IResult> GetGameOddsInDateRange(DateTime startDate, DateTime endDate)
        {
            var dateRange = new DateRange
            {
                startDate = startDate.Date,
                endDate = endDate.Date
            };
            var predictedGames = await _gameOddsGetter.GetGameOddsInDateRange(dateRange);
            var predictedGamesVM = GameOddsToViewModelsMapper.Map(predictedGames);
            return Results.Ok(predictedGamesVM);
        }
    }
}
