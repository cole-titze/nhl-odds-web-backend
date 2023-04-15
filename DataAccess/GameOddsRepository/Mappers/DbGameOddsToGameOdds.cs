using System;
using System.Reflection;
using DataAccess.TeamRepository.Mappers;
using Entities.DbModels;
using Entities.Types;

namespace DataAccess.GameOddsRepository.Mappers
{
	public static class DbGameOddsToGameOddsMapper
	{
		public static IEnumerable<GameOdds> Map(IEnumerable<DbGameOdds> dbGameOdds)
		{
			var gameOdds = new List<GameOdds>();
			foreach(var dbGameOdd in dbGameOdds)
			{
				gameOdds.Add(
					new GameOdds()
					{
						game = new Game()
						{
							id = dbGameOdd.gameId,
                            gameDate = dbGameOdd.game.gameDate,
                            homeGoals = dbGameOdd.game.homeGoals,
							awayGoals = dbGameOdd.game.awayGoals,
                            seasonStartYear = dbGameOdd.game.seasonStartYear,
                            winner = dbGameOdd.game.winner,
                            hasBeenPlayed = dbGameOdd.game.hasBeenPlayed,
                            homeTeam = DbTeamToTeamMapper.Map(dbGameOdd.game.homeTeam),
                            awayTeam = DbTeamToTeamMapper.Map(dbGameOdd.game.awayTeam),
                        },
						vegasAwayOdds = dbGameOdd.bovadaClosingVegasAwayOdds,
						vegasHomeOdds = dbGameOdd.bovadaClosingVegasHomeOdds,
						modelAwayOdds = dbGameOdd.modelAwayOdds,
						modelHomeOdds = dbGameOdd.modelHomeOdds,
					}
				);
			}

			return gameOdds;
		}
	}
}

