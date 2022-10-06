using System;
using Entities.Models;
using Entities.ViewModels;

namespace WebApi.Mappers
{
	public static class TeamDbToTeamVmMapper
	{
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

