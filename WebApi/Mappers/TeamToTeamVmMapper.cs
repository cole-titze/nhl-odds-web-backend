using Entities.Types;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class TeamToTeamVmMapper
	{
        /// <summary>
        /// Converts a team object to a view model
        /// </summary>
        /// <param name="teamsStats">The teams to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static IEnumerable<TeamViewModel> Map(IEnumerable<TeamStats> teamsStats)
        {
            List<TeamViewModel> teamsVm = new List<TeamViewModel>();

            foreach(var teamStat in teamsStats)
            {
                var teamVm = new TeamViewModel
                {
                    id = teamStat.team.id,
                    locationName = teamStat.team.locationName,
                    teamName = teamStat.team.teamName,
                    logoUri = teamStat.team.logoUri,
                    vegasLogLoss = teamStat.vegasLogLoss,
                    modelLogLoss = teamStat.modelLogLoss
                };
                teamsVm.Add(teamVm);
            }
            return teamsVm;
        }
    }
}

