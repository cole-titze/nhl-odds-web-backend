using Entities.Models;
using Entities.DbModels;

namespace DataAccess.Mappers
{
    public static class DbTeamsToTeamsMapper
    {
        /// <summary>
        /// Maps a database team object to a BL Team
        /// </summary>
        /// <param name="dbTeams">The database teams to convert</param>
        /// <returns>Team objects</returns>
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

