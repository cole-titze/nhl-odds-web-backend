using Entities.DbModels;
using Entities.Types;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class TeamsToTeamsVmMapper
	{
        /// <summary>
        /// Converts a team object to a view model
        /// </summary>
        /// <param name="teamsStats">The teams to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static TeamsVM Map(IEnumerable<TeamStats> teamsStats)
        {
            List<TeamVM> teams = new List<TeamVM>();
            var teamsVm = new TeamsVM();

            foreach(var teamStat in teamsStats)
            {
                var teamVm = new TeamVM
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
                teams.Add(teamVm);
            }
            teamsVm.teams = teams;
            teamsVm = BuildSeasonTotals(teamsVm);

            return teamsVm;
        }
        /// <summary>
        /// Builds the season stats view model
        /// </summary>
        /// <param name="teamsVm">The view model to use to build the season stats object</param>
        /// <returns>The teams view model</returns>
        private static TeamsVM BuildSeasonTotals(TeamsVM teamsVm)
        {
            foreach(var team in teamsVm.teams)
            {
                teamsVm.seasonTotals.totalGameCount += team.totalGames;
                teamsVm.seasonTotals.totalModelAccurateGameCount += team.totalAccurateModelGames;
                teamsVm.seasonTotals.totalVegasAccurateGameCount += team.totalAccurateVegasGames;
                teamsVm.seasonTotals.modelLogLossTotal += (team.modelLogLoss * team.totalGames);
                teamsVm.seasonTotals.vegasLogLossTotal += (team.vegasLogLoss * team.totalGames);
            }
            teamsVm.seasonTotals.vegasLogLossTotal /= teamsVm.seasonTotals.totalGameCount;
            teamsVm.seasonTotals.modelLogLossTotal /= teamsVm.seasonTotals.totalGameCount;

            // Cut in half since we were counting games twice (home and away)
            teamsVm.seasonTotals.totalGameCount /= 2;
            teamsVm.seasonTotals.totalModelAccurateGameCount /= 2;
            teamsVm.seasonTotals.totalVegasAccurateGameCount /= 2;

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

