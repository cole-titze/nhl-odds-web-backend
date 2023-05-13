using Entities.Types;
using Entities.DbModels;

namespace DataAccess.TeamRepository.Mappers
{
    public static class DbTeamToTeamStatsMapper
    {
        /// <summary>
        /// Maps a database team object to a BL Team
        /// </summary>
        /// <param name="dbTeam">The database team to convert</param>
        /// <returns>Team stats object</returns>
        public static TeamStats Map(DbTeam dbTeam)
        {
            var teamStats = new TeamStats
            {
                team = DbTeamToTeamMapper.Map(dbTeam)
            };

            return teamStats;
        }
    }
}

