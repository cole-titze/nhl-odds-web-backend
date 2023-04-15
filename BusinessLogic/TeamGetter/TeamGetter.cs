using DataAccess.LogLossRepository;
using DataAccess.TeamRepository;
using Entities.DbModels;
using Entities.Types;

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
        /// <summary>
        /// Builds the log losses into the Team object
        /// </summary>
        /// <param name="seasonStartYear">The year to get the log loss from</param>
        /// <returns>List of filled teams</returns>
        public async Task<IEnumerable<TeamStats>> GetTeamStats(int seasonStartYear)
        {
            var logLosses = await _logLossRepository.GetAllLogLossesForSeason(seasonStartYear);
            var teamsStats = await _teamRepository.GetAllTeams();

            teamsStats = GetActiveTeams(teamsStats, logLosses);
            BuildTeamLogLosses(teamsStats, logLosses);

            return teamsStats;
        }

        /// <summary>
        /// Gets teams that are active for the current season
        /// </summary>
        /// <param name="teamsStats"></param>
        /// <returns>Team stats that are active in the list</returns>
        private static IEnumerable<TeamStats> GetActiveTeams(IEnumerable<TeamStats> teamsStats, IEnumerable<DbLogLoss> logLosses)
        {
            var activeTeams = new List<TeamStats>();
            foreach (var teamStat in teamsStats)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == teamStat.team.id || x.game.homeTeamId == teamStat.team.id)).ToList();
                if (teamLogLosses.Count == 0)
                    continue;

                activeTeams.Add(teamStat);
            }

            return activeTeams;
        }

        /// <summary>
        /// Finds the season log loss for each team. If a team has no log losses they are removed from the list
        /// </summary>
        /// <param name="teamsStats">The teams to calculate the log loss for</param>
        /// <param name="logLosses">Game log losses</param>
        /// <returns>List of filled teams</returns>
        private static void BuildTeamLogLosses(IEnumerable<TeamStats> teamsStats, IEnumerable<DbLogLoss> logLosses)
        {
            foreach(var teamStats in teamsStats)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == teamStats.team.id || x.game.homeTeamId == teamStats.team.id)).ToList();

                BuildTeamLogLoss(teamStats, teamLogLosses);
            }
        }

        /// <summary>
        /// Given a team's games log losses the team's log losses are calculated and filled
        /// </summary>
        /// <param name="teamStats">A team's stats</param>
        /// <param name="teamLogLosses">The log losses for a team</param>
        private static void BuildTeamLogLoss(TeamStats teamStats, IEnumerable<DbLogLoss> teamLogLosses)
        {
            foreach (var logLoss in teamLogLosses)
            {
                teamStats.vegasLogLoss += logLoss.bovadaLogLoss;
                teamStats.modelLogLoss += logLoss.modelLogLoss;
            }
            teamStats.vegasLogLoss /= teamLogLosses.Count();
            teamStats.modelLogLoss /= teamLogLosses.Count();
        }
    }
}
