using System;
using Entities.DbModels;
using Entities.Models;
using Entities.ViewModels;
namespace WebApi.Mappers
{
	public static class PredictedGamesToViewModelsMapper
	{
		public static IEnumerable<PredictedGameViewModel> Map(IEnumerable<DbPredictedGame> games)
		{
			List<PredictedGameViewModel> viewModelGames = new List<PredictedGameViewModel>();
			foreach(var game in games)
			{
				var awayTeam = new TeamViewModel
				{
					id = game.awayTeamId,
					locationName = game.awayTeam.locationName,
					teamName = game.awayTeam.teamName,
					logoUri = game.awayTeam.logoUri,
					vegasOdds = game.bovadaOpeningVegasAwayOdds,
					modelOdds = game.modelAwayOdds,
					goals = game.game.awayGoals,
					team = TEAM.away
				};
                var homeTeam = new TeamViewModel
                {
                    id = game.homeTeamId,
                    locationName = game.homeTeam.locationName,
                    teamName = game.homeTeam.teamName,
                    logoUri = game.homeTeam.logoUri,
                    vegasOdds = game.bovadaOpeningVegasHomeOdds,
                    modelOdds = game.modelHomeOdds,
					goals = game.game.homeGoals,
					team = TEAM.home
                };
				var viewModelGame = new PredictedGameViewModel
				{
					id = game.id,
					gameDate = game.gameDate,
					awayTeam = awayTeam,
					homeTeam = homeTeam,
					winner = game.cleanedGame.winner,
					hasBeenPlayed = game.cleanedGame.hasBeenPlayed
				};
				viewModelGames.Add(viewModelGame);
			}
			return viewModelGames;
		}
	}
}

