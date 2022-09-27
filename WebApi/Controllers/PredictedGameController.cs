﻿using BusinessLogic.LogLoss;
using BusinessLogic.PredictedGameGetter;
using DataAccess.PredictedGameRepository;
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
        [HttpGet]
        public async Task<IResult> GetAllPredictedGames()
        {
            var predictedGames = await _predictedGameGetter.GetPredictedGames();
            var predictedGamesVM = PredictedGamesToViewModelsMapper.Map(predictedGames);
            return Results.Ok(predictedGamesVM);
        }
        [HttpGet]
        public async Task<IResult> GetAllGamesOnDate([FromBody]DateTime day)
        {
            var predictedGames = await _predictedGameGetter.GetPredictedGamesOnDate(day);
            return Results.Ok(predictedGames);
        }
    }
}

