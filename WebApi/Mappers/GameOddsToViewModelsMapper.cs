﻿using Entities.DbModels;
using Entities.ViewModels;
namespace WebApi.Mappers
{
    public static class GameOddsToViewModelsMapper
	{
		/// <summary>
		/// Converts Game odds into a view model for the frontend to use
		/// </summary>
		/// <param name="games">The game odds to convert</param>
		/// <returns>View model for displaying game odds</returns>
		public static IEnumerable<GameOddsViewModel> Map(IEnumerable<DbGameOdds> games)
		{
			List<GameOddsViewModel> viewModelGames = new List<GameOddsViewModel>();
			foreach(var gameOdds in games)
			{
				var awayTeam = new MatchupTeamViewModel
				{
					id = gameOdds.game.awayTeamId,
					locationName = gameOdds.game.awayTeam.locationName,
					teamName = gameOdds.game.awayTeam.teamName,
					logoUri = gameOdds.game.awayTeam.logoUri,
					vegasOdds = gameOdds.bovadaOpeningVegasAwayOdds,
					modelOdds = gameOdds.modelAwayOdds,
					goals = gameOdds.game.awayGoals,
					team = TEAM.away
				};
                var homeTeam = new MatchupTeamViewModel
                {
                    id = gameOdds.game.homeTeamId,
                    locationName = gameOdds.game.homeTeam.locationName,
                    teamName = gameOdds.game.homeTeam.teamName,
                    logoUri = gameOdds.game.homeTeam.logoUri,
                    vegasOdds = gameOdds.bovadaOpeningVegasHomeOdds,
                    modelOdds = gameOdds.modelHomeOdds,
					goals = gameOdds.game.homeGoals,
					team = TEAM.home
                };
				var viewModelGame = new GameOddsViewModel
				{
					id = gameOdds.gameId,
					gameDate = gameOdds.game.gameDate,
					awayTeam = awayTeam,
					homeTeam = homeTeam,
					winner = gameOdds.game.winner,
					hasBeenPlayed = gameOdds.game.hasBeenPlayed
				};
				viewModelGames.Add(viewModelGame);
			}
			return viewModelGames;
		}
	}
}

