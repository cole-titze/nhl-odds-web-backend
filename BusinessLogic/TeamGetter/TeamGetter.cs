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
        /// Gets the team stats for all teams
        /// </summary>
        /// <param name="seasonStartYear">The year to get the log loss from</param>
        /// <returns>List of filled team stats</returns>
        public async Task<IEnumerable<TeamStats>> GetAllTeamsStats(int seasonStartYear)
        {
            var logLosses = await _logLossRepository.GetAllLogLossesForSeason(seasonStartYear);
            var teamsStats = await _teamRepository.GetAllTeams();

            teamsStats = GetActiveTeams(teamsStats, logLosses);
            BuildTeamsLogLosses(teamsStats, logLosses);

            return teamsStats;
        }

        /// <summary>
        /// Gets the team stats for a given team
        /// </summary>
        /// <param name="teamId">The team to get stats for</param>
        /// <param name="seasonStartYear">The year to get log losses for</param>
        /// <returns>Filled stats for the given team</returns>
        public async Task<TeamStats> GetTeamStats(int teamId, int seasonStartYear)
        {
            var teamLogLosses = await _logLossRepository.GetTeamLogLossesForSeason(teamId, seasonStartYear);
            var teamStats = await _teamRepository.GetTeam(teamId);

            BuildTeamLogLosses(teamStats, teamLogLosses);

            return teamStats;
        }

        /// <summary>
        /// Gets teams that are active for the current season
        /// </summary>
        /// <param name="teamsStats">All teams stats</param>
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
        private static void BuildTeamsLogLosses(IEnumerable<TeamStats> teamsStats, IEnumerable<DbLogLoss> logLosses)
        {
            foreach(var teamStats in teamsStats)
            {
                var teamLogLosses = logLosses.Where(x => (x.game.awayTeamId == teamStats.team.id || x.game.homeTeamId == teamStats.team.id)).ToList();

                BuildTeamLogLosses(teamStats, teamLogLosses);
            }
        }

        /// <summary>
        /// Given a team's games log losses the team's log losses are calculated and filled
        /// </summary>
        /// <param name="teamStats">A team's stats</param>
        /// <param name="teamLogLosses">The log losses for a team</param>
        private static void BuildTeamLogLosses(TeamStats teamStats, IEnumerable<DbLogLoss> teamLogLosses)
        {
            if (!teamLogLosses.Any())
                return;

            foreach (var logLoss in teamLogLosses)
            {
                teamStats.vegasLogLoss += logLoss.draftKingsLogLoss;
                teamStats.modelLogLoss += logLoss.modelLogLoss;
            }

            teamStats.vegasLogLoss /= teamLogLosses.Count();
            teamStats.modelLogLoss /= teamLogLosses.Count();
        }
    }
}
