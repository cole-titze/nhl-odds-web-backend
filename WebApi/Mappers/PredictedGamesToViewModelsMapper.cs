using Entities.DbModels;
using Entities.ViewModels;
namespace WebApi.Mappers
{
    public static class PredictedGamesToViewModelsMapper
	{
		public static IEnumerable<PredictedGameViewModel> Map(IEnumerable<DbGameOdds> games)
		{
			List<PredictedGameViewModel> viewModelGames = new List<PredictedGameViewModel>();
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
				var viewModelGame = new PredictedGameViewModel
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

