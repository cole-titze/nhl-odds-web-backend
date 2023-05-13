using Entities.Types;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class TeamsToTeamsVmMapper
    {
        /// <summary>
        /// Converts a team object to a view model
        /// </summary>
        /// <param name="teamsStats">The teams to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static TeamsVM Map(IEnumerable<TeamStats> teamsStats)
        {
            List<TeamVM> teams = new List<TeamVM>();
            var teamsVm = new TeamsVM();

            foreach (var teamStats in teamsStats)
            {
                var teamVm = TeamToTeamVmMapper.Map(teamStats);
                teams.Add(teamVm);
            }
            teamsVm.teams = teams;
            teamsVm = BuildSeasonTotals(teamsVm);

            return teamsVm;
        }
        /// <summary>
        /// Builds the season stats view model
        /// </summary>
        /// <param name="teamsVm">The view model to use to build the season stats object</param>
        /// <returns>The teams view model</returns>
        private static TeamsVM BuildSeasonTotals(TeamsVM teamsVm)
        {
            foreach (var team in teamsVm.teams)
            {
                teamsVm.seasonTotals.totalGameCount += team.totalGameCount;
                teamsVm.seasonTotals.totalModelAccurateGameCount += team.totalModelAccurateGameCount;
                teamsVm.seasonTotals.totalVegasAccurateGameCount += team.totalVegasAccurateGameCount;
                teamsVm.seasonTotals.modelLogLoss += (team.modelLogLoss * team.totalGameCount);
                teamsVm.seasonTotals.vegasLogLoss += (team.vegasLogLoss * team.totalGameCount);
            }
            teamsVm.seasonTotals.vegasLogLoss /= teamsVm.seasonTotals.totalGameCount;
            teamsVm.seasonTotals.modelLogLoss /= teamsVm.seasonTotals.totalGameCount;

            // Cut in half since we were counting games twice (home and away)
            teamsVm.seasonTotals.totalGameCount /= 2;
            teamsVm.seasonTotals.totalModelAccurateGameCount /= 2;
            teamsVm.seasonTotals.totalVegasAccurateGameCount /= 2;

            return teamsVm;
        }
    }
}