using Entities.DbModels;
using Entities.Types;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class TeamToTeamVmMapper
	{
        /// <summary>
        /// Converts a team object to a view model
        /// </summary>
        /// <param name="teamsStats">The teams to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static IEnumerable<TeamViewModel> Map(IEnumerable<TeamStats> teamsStats)
        {
            List<TeamViewModel> teamsVm = new List<TeamViewModel>();

            foreach(var teamStat in teamsStats)
            {
                var teamVm = new TeamViewModel
                {
                    id = teamStat.team.id,
                    locationName = teamStat.team.locationName,
                    teamName = teamStat.team.teamName,
                    logoUri = teamStat.team.logoUri,
                    vegasLogLoss = teamStat.vegasLogLoss,
                    modelLogLoss = teamStat.modelLogLoss,
                    totalGames = teamStat.gameOdds.Count(),
                    totalAccurateModelGames = GetCorrectModelPredictionCount(teamStat.gameOdds),
                    totalAccurateVegasGames = GetCorrectVegasPredictionCount(teamStat.gameOdds),
                };
                teamsVm.Add(teamVm);
            }
            return teamsVm;
        }
        /// <summary>
        /// Gets the correct game count of personal model
        /// </summary>
        /// <param name="gameOdds">The games to check</param>
        /// <returns>The number of games predicted correctly</returns>
        private static int GetCorrectModelPredictionCount(IEnumerable<GameOdds> gameOdds)
        {
            int correctCount = 0;
            foreach(var gameOdd in gameOdds)
            {
                correctCount += IsCorrectlyPredicted(gameOdd.game, gameOdd.modelHomeOdds, gameOdd.modelAwayOdds);
            }

            return correctCount;
        }
        /// <summary>
        /// Gets the correct game count of vegas model
        /// </summary>
        /// <param name="gameOdds">The games to check</param>
        /// <returns>The number of games predicted correctly</returns>
        private static int GetCorrectVegasPredictionCount(IEnumerable<GameOdds> gameOdds)
        {
            int correctCount = 0;
            foreach (var gameOdd in gameOdds)
            {
                correctCount += IsCorrectlyPredicted(gameOdd.game, gameOdd.vegasHomeOdds, gameOdd.vegasAwayOdds);
            }

            return correctCount;
        }
        /// <summary>
        /// Checks if the game was correctly predicted or not
        /// </summary>
        /// <param name="game">The game to check</param>
        /// <param name="homeOdds">The predicted home odds</param>
        /// <param name="awayOdds">The predicted away odds</param>
        /// <returns>1 if correctly predicted, 0 if not or if the game hasn't been played</returns>
        private static int IsCorrectlyPredicted(Game game, double homeOdds, double awayOdds)
        {
            if (!game.hasBeenPlayed)
                return 0;

            if (homeOdds > .5 && game.winner == TEAM.home)
                return 1;
            else if (awayOdds > .5 && game.winner == TEAM.away)
                return 1;

            return 0;
        }
    }
}

