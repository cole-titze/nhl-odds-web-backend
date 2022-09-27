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
				var awayTeam = new Team
				{
					id = game.awayTeamId,
					locationName = game.awayTeam.locationName,
					teamName = game.awayTeam.teamName,
					logoUri = game.awayTeam.logoUri,
					vegasOdds = game.myBookieOpeningVegasAwayOdds,
					modelOdds = game.modelAwayOdds
				};
                var homeTeam = new Team
                {
                    id = game.homeTeamId,
                    locationName = game.homeTeam.locationName,
                    teamName = game.homeTeam.teamName,
                    logoUri = game.homeTeam.logoUri,
                    vegasOdds = game.myBookieOpeningVegasHomeOdds,
                    modelOdds = game.modelHomeOdds
                };
                var viewModelGame = new PredictedGameViewModel
				{
					id = game.id,
					gameDate = game.gameDate,
					awayTeam = awayTeam,
					homeTeam = homeTeam
				};
				viewModelGames.Add(viewModelGame);
			}
			return viewModelGames;
		}
	}
}

