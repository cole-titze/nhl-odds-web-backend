using System;
using Entities.Models;

namespace BusinessLogic.TeamGetter
{
    public interface ITeamGetter
    {
        Task<IEnumerable<Team>> GetAllTeams();
        Task<IEnumerable<Team>> BuildLogLosses(IEnumerable<Team> teams, int startYear);
    }
}
