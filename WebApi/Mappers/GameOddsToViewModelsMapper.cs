using Entities.DbModels;
using Entities.Types;
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
		public static IEnumerable<GameOddsVM> Map(IEnumerable<GameOdds> games)
		{
			List<GameOddsVM> viewModelGames = new List<GameOddsVM>();
			foreach(var gameOdds in games)
			{
				var awayTeam = new MatchupTeamVM
				{
					id = gameOdds.game.awayTeam.id,
					locationName = gameOdds.game.awayTeam.locationName,
					teamName = gameOdds.game.awayTeam.teamName,
					logoUri = gameOdds.game.awayTeam.logoUri,
					vegasOdds = gameOdds.vegasAwayOdds,
					modelOdds = gameOdds.modelAwayOdds,
					goals = gameOdds.game.awayGoals,
					team = TEAM.away
				};
                var homeTeam = new MatchupTeamVM
                {
                    id = gameOdds.game.homeTeam.id,
                    locationName = gameOdds.game.homeTeam.locationName,
                    teamName = gameOdds.game.homeTeam.teamName,
                    logoUri = gameOdds.game.homeTeam.logoUri,
                    vegasOdds = gameOdds.vegasHomeOdds,
                    modelOdds = gameOdds.modelHomeOdds,
					goals = gameOdds.game.homeGoals,
					team = TEAM.home
                };
				var viewModelGame = new GameOddsVM
				{
					id = gameOdds.game.id,
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

