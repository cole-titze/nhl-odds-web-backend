using System;
using Entities.DbModels;
using Entities.Models;

namespace DataAccess.Mappers
{
	public static class DbPredictedGameToGameOddsMapper
	{
        public static IEnumerable<GameOdds> Map(IEnumerable<DbTeam> dbTeams)
        {
            var teamsList = new List<GameOdds>();
            foreach (var dbTeam in dbTeams)
            {
                var gameOdds = new GameOdds
                {
                };
                teamsList.Add(gameOdds);
            }
            return teamsList;
        }
    }
}

