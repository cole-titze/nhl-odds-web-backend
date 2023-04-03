using BusinessLogic.TeamGetter;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController
    {
        private readonly ILogger<GameOddsController> _logger;
        private readonly ITeamGetter _teamGetter;

        public TeamController(ILogger<GameOddsController> logger, ITeamGetter predictedGameBL)
        {
            _logger = logger;
            _teamGetter = predictedGameBL;
        }

        [HttpGet]
        public async Task<IResult> GetAllTeams(int seasonStartYear)
        {
            var teamsWithLogLoss = await _teamGetter.BuildLogLosses(seasonStartYear);
            var teamsVm = TeamToTeamVmMapper.Map(teamsWithLogLoss);
            return Results.Ok(teamsVm);
        }
    }
}
