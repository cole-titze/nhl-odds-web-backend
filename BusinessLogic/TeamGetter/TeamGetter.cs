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
        public async Task<IList<Team>> GetAllTeams()
        {
            return await _teamRepository.GetAllTeams();
        }

        public async Task<IEnumerable<Team>> BuildLogLosses(int startYear)
        {
            var logLosses = await _logLossRepository.GetAllLogLossesForSeason(startYear);
            var teams = await GetAllTeams();
            teams = buildTeamLogLosses(teams, logLosses);

            return teams;
        }

        private IList<Team> buildTeamLogLosses(IList<Team> teams, IEnumerable<DbLogLoss> logLosses)
        {
            var teamsToRemove = new List<Team>();
            foreach(var team in teams)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == team.id || x.game.homeTeamId == team.id)).ToList();
                if (teamLogLosses.Count() == 0)
                {
                    teamsToRemove.Add(team);
                    continue;
                }

                foreach (var logLoss in teamLogLosses)
                {
                    team.vegasLogLoss += logLoss.bovadaLogLoss;
                    team.modelLogLoss += logLoss.modelLogLoss;
                }
                team.vegasLogLoss /= teamLogLosses.Count();
                team.modelLogLoss /= teamLogLosses.Count();
            }
            foreach(var team in teamsToRemove)
            {
                teams.Remove(team);
            }

            return teams;
        }
    }
}
