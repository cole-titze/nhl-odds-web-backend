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
        /// <summary>
        /// Gets log losses of teams for a given season
        /// </summary>
        /// <param name="seasonStartYear">The season to get stats on</param>
        /// <returns>A list of team view models that hold the log losses for the year</returns>
        [HttpGet]
        public async Task<IResult> GetAllTeams(int seasonStartYear)
        {
            var teamsWithLogLoss = await _teamGetter.GetTeamStats(seasonStartYear);
            var teamsVm = TeamToTeamVmMapper.Map(teamsWithLogLoss);
            return Results.Ok(teamsVm);
        }
    }
}
