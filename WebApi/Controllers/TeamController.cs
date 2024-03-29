﻿using BusinessLogic.GameOddsGetter;
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
        private readonly IGameOddsGetter _gameOddsGetter;

        public TeamController(ILogger<GameOddsController> logger, ITeamGetter predictedGameBL, IGameOddsGetter gameOddsBL)
        {
            _logger = logger;
            _teamGetter = predictedGameBL;
            _gameOddsGetter = gameOddsBL;
        }
        /// <summary>
        /// Gets log losses of teams for a given season
        /// </summary>
        /// <param name="seasonStartYear">The season to get stats on</param>
        /// <returns>A list of team view models that hold the log losses for the year</returns>
        [HttpGet]
        public async Task<IResult> GetAllTeams(int seasonStartYear)
        {
            var teams = await _teamGetter.GetAllTeamsStats(seasonStartYear);
            teams = await _gameOddsGetter.BuildTeamsGameOdds(teams, seasonStartYear);
            var teamsVm = TeamsToTeamsVmMapper.Map(teams);
            return Results.Ok(teamsVm);
        }
        /// <summary>
        /// Gets team information for a season
        /// </summary>
        /// <param name="teamId">The team to get stats on</param>
        /// <param name="seasonStartYear">The season to get stats on</param>
        /// <returns>A team view model that holds the log losses for the year</returns>
        [HttpGet]
        public async Task<IResult> GetTeam(int teamId, int seasonStartYear)
        {
            var team = await _teamGetter.GetTeamStats(teamId, seasonStartYear);
            team = await _gameOddsGetter.BuildTeamGameOdds(team, seasonStartYear);
            var teamVm = TeamToTeamVmMapper.Map(team);
            return Results.Ok(teamVm);
        }
    }
}
