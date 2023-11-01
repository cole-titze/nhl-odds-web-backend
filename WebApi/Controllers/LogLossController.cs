using BusinessLogic.GameOddsGetter;
using BusinessLogic.LogLossGetter;
using Entities.Types;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogLossController
    {
        private readonly ILogger<GameOddsController> _logger;
        private readonly ILogLossGetter _logLossGetter;

        public LogLossController(ILogger<GameOddsController> logger, ILogLossGetter logLossGetter)
        {
            _logger = logger;
            _logLossGetter = logLossGetter;
        }

        /// <summary>
        /// Gets log losses for the given team and season year. If no team specified gets all teams.
        /// </summary>
        /// <param name="seasonStartYear">Year to get log losses for</param>
        /// <param name="teamId">Team to get the games for</param>
        /// <returns>List of log losses for the given year and team</returns>
        [HttpGet]
        public async Task<IResult> GetLogLosses(int seasonStartYear, int? teamId)
        {
            var logLosses = await _logLossGetter.GetLogLosses(seasonStartYear, teamId);
            var logLossVMs = DbLogLossesToViewModel.Map(logLosses);
            return Results.Ok(logLossVMs);
        }
        /// <summary>
        /// Gets the average log losses over a series of games. These are points ready to be turned into a graph
        /// </summary>
        /// <param name="seasonStartYear">Year to get the points for</param>
        /// <param name="teamId">Team to get the points for</param>
        /// <returns>A list of x (game points) and y (average log loss) points</returns>
        [HttpGet]
        public async Task<IResult> GetLogLossPoints(int seasonStartYear, int? teamId)
        {
            var logLosses = await _logLossGetter.GetLogLosses(seasonStartYear, teamId);
            var pointVM = DbLogLossesToPointViewModel.Map(logLosses);
            return Results.Ok(pointVM);
        }
    }
}
