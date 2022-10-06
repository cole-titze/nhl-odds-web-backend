using System;
using DataAccess.LogLossRepository;
using DataAccess.TeamRepository;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.TeamGetter
{
    public class TeamGetter : ITeamGetter
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILogLossRepository _logLossRepository;

        public TeamGetter(ITeamRepository teamRepository, ILogLossRepository logLossRepository)
        {
            _teamRepository = teamRepository;
            _logLossRepository = logLossRepository;
        }
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await _teamRepository.GetAllTeams();
        }

        public async Task<IEnumerable<Team>> BuildLogLosses(IEnumerable<Team> teams, int startYear)
        {
            var logLosses = await _logLossRepository.GetAllLogLossesForSeason(startYear);
            foreach(var team in teams)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == team.id || x.game.homeTeamId == team.id)).ToList();
                if (teamLogLosses.Count() == 0)
                    continue;

                foreach(var logLoss in teamLogLosses)
                {
                    team.vegasLogLoss += logLoss.bovadaLogLoss;
                    team.modelLogLoss += logLoss.modelLogLoss;
                }
                team.vegasLogLoss /= teamLogLosses.Count();
                team.modelLogLoss /= teamLogLosses.Count();
            }
            return teams;
        }
    }
}
