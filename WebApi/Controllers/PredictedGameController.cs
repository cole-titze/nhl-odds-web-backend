using DataAccess.PredictedGameRepository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PredictedGameController
	{
        private readonly ILogger<PredictedGameController> _logger;
        private readonly IPredictedGameRepository _predictedGameRepository;

        public PredictedGameController(ILogger<PredictedGameController> logger, IPredictedGameRepository predictedGameRepository)
        {
            _logger = logger;
            _predictedGameRepository = predictedGameRepository;
        }
        [HttpGet]
        public async Task<IResult> GetAllPredictedGames()
        {
            var predictedGames = await _predictedGameRepository.GetPredictedGames();
            return Results.Ok(predictedGames);
        }
    }
}

