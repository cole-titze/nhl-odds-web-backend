using Entities.Models;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class TeamToTeamVmMapper
	{
        /// <summary>
        /// Converts a team object to a view model
        /// </summary>
        /// <param name="teams">The teams to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static IEnumerable<TeamViewModel> Map(IEnumerable<Team> teams)
        {
            List<TeamViewModel> teamsVm = new List<TeamViewModel>();

            foreach(var team in teams)
            {
                var teamVm = new TeamViewModel
                {
                    id = team.id,
                    locationName = team.locationName,
                    teamName = team.teamName,
                    logoUri = team.logoUri,
                    vegasLogLoss = team.vegasLogLoss,
                    modelLogLoss = team.modelLogLoss
                };
                teamsVm.Add(teamVm);
            }
            return teamsVm;
        }
    }
}

