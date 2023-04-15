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
        public async Task<IList<TeamStats>> GetAllTeams()
        {
            return await _teamRepository.GetAllTeams();
        }
        /// <summary>
        /// Builds the log losses into the Team object
        /// </summary>
        /// <param name="startYear">The year to get the log loss from</param>
        /// <returns>List of filled teams</returns>
        public async Task<IEnumerable<TeamStats>> GetTeamLogLosses(int startYear)
        {
            var logLosses = await _logLossRepository.GetAllLogLossesForSeason(startYear);
            var teams = await GetAllTeams();
            teams = BuildTeamLogLosses(teams, logLosses);

            return teams;
        }
        /// <summary>
        /// Finds the season log loss for each team. If a team has no log losses they are removed from the list
        /// </summary>
        /// <param name="teams">The teams to calculate the log loss for</param>
        /// <param name="logLosses">Game log losses</param>
        /// <returns>List of filled teams</returns>
        private static IList<TeamStats> BuildTeamLogLosses(IList<TeamStats> teams, IEnumerable<DbLogLoss> logLosses)
        {
            var teamsToRemove = new List<TeamStats>();
            foreach(var team in teams)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == team.id || x.game.homeTeamId == team.id)).ToList();
                if (teamLogLosses.Count == 0)
                {
                    teamsToRemove.Add(team);
                    continue;
                }

                foreach (var logLoss in teamLogLosses)
                {
                    team.vegasLogLoss += logLoss.bovadaLogLoss;
                    team.modelLogLoss += logLoss.modelLogLoss;
                }
                team.vegasLogLoss /= teamLogLosses.Count;
                team.modelLogLoss /= teamLogLosses.Count;
            }
            foreach(var team in teamsToRemove)
            {
                teams.Remove(team);
            }

            return teams;
        }
    }
}
