using Entities.Models;
using Entities.DbModels;

namespace DataAccess.Mappers
{
    public static class DbTeamsToTeamsMapper
    {
        public static IList<Team> Map(IEnumerable<DbTeam> dbTeams)
        {
            var teamsList = new List<Team>();
            foreach(var dbTeam in dbTeams)
            {
                var team = new Team
                {
                    id = dbTeam.id,
                    teamName = dbTeam.teamName,
                    locationName = dbTeam.locationName,
                    logoUri = dbTeam.logoUri
                };
                teamsList.Add(team);
            }
            return teamsList;
        }
    }
}

