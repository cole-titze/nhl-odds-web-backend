using System;
using Entities.DbModels;
using Entities.Types;

namespace DataAccess.TeamRepository.Mappers
{
	public static class DbTeamToTeamMapper
	{
		public static Team Map(DbTeam dbTeam)
		{
            return new Team()
            {
                id = dbTeam.id,
                teamName = dbTeam.teamName,
                locationName = dbTeam.locationName,
                logoUri = dbTeam.logoUri,
            };
        }
	}
}

