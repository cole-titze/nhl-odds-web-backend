using BusinessLogic.LogLoss;
using BusinessLogic.PredictedGameGetter;
using BusinessLogic.TeamGetter;
using DataAccess.PredictedGameRepository;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController
    {
        private readonly ILogger<PredictedGameController> _logger;
        private readonly ITeamGetter _teamGetter;

        public TeamController(ILogger<PredictedGameController> logger, ITeamGetter predictedGameBL)
        {
            _logger = logger;
            _teamGetter = predictedGameBL;
        }

        [HttpGet]
        public async Task<IResult> GetAllTeams(int seasonStartYear)
        {
            var teams = await _teamGetter.GetAllTeams();
            var teamsWithLogLoss = await _teamGetter.BuildLogLosses(teams, seasonStartYear);
            var teamsVm = TeamDbToTeamVmMapper.Map(teamsWithLogLoss);
            return Results.Ok(teamsVm);
        }
    }
}
