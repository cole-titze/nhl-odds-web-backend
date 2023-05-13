using Entities.Types;
using Entities.DbModels;

namespace DataAccess.TeamRepository.Mappers
{
    public static class DbTeamsToTeamStatsMapper
    {
        /// <summary>
        /// Maps a database team object to a BL Team
        /// </summary>
        /// <param name="dbTeams">The database teams to convert</param>
        /// <returns>Team objects</returns>
        public static IEnumerable<TeamStats> Map(IEnumerable<DbTeam> dbTeams)
        {
            var teamsList = new List<TeamStats>();
            foreach(var dbTeam in dbTeams)
            {
                var teamStats = DbTeamToTeamStatsMapper.Map(dbTeam);
                teamsList.Add(teamStats);
            }

            return teamsList;
        }
    }
}

