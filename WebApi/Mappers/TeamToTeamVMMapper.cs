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
        /// <param name="teamStats">The team to convert</param>
        /// <returns>View model for displaying teams</returns>
        public static TeamVM Map(TeamStats teamStats)
        {
            var teamVm = new TeamVM
            {
                id = teamStats.team.id,
                locationName = teamStats.team.locationName,
                teamName = teamStats.team.teamName,
                logoUri = teamStats.team.logoUri,
                vegasLogLoss = teamStats.vegasLogLoss,
                modelLogLoss = teamStats.modelLogLoss,
                totalGameCount = teamStats.gameOdds.Count(),
                seasonWins = GetWins(teamStats.team.id, teamStats.gameOdds),
                seasonLosses = GetLosses(teamStats.team.id, teamStats.gameOdds),
                totalModelAccurateGameCount = GetCorrectModelPredictionCount(teamStats.gameOdds),
                totalVegasAccurateGameCount = GetCorrectVegasPredictionCount(teamStats.gameOdds),
                gameOddsVM = GameOddsToViewModelsMapper.Map(teamStats.gameOdds),
            };

            return teamVm;
        }
        /// <summary>
        /// Gets the wins for a given team
        /// </summary>
        /// <param name="teamId">The team to get wins for</param>
        /// <param name="gameOdds">The games to get wins from</param>
        /// <returns>The number of wins for a team in a season</returns>
        private static int GetWins(int teamId, IEnumerable<GameOdds> gameOdds)
        {
            int wins = 0;
            foreach(var gameOdd in gameOdds)
            {
                wins += gameOdd.game.IsWin(teamId);
            }

            return wins;
        }

        /// <summary>
        /// Gets the losses for a given team
        /// </summary>
        /// <param name="teamId">The team to get losses for</param>
        /// <param name="gameOdds">The games to get losses from</param>
        /// <returns>The number of losses for a team in a season</returns>
        private static int GetLosses(int teamId, IEnumerable<GameOdds> gameOdds)
        {
            int wins = 0;
            foreach (var gameOdd in gameOdds)
            {
                wins += gameOdd.game.IsLoss(teamId);
            }

            return wins;
        }

        /// <summary>
        /// Gets the correct game count of personal model
        /// </summary>
        /// <param name="gameOdds">The games to check</param>
        /// <returns>The number of games predicted correctly</returns>
        private static int GetCorrectModelPredictionCount(IEnumerable<GameOdds> gameOdds)
        {
            int correctCount = 0;
            foreach (var gameOdd in gameOdds)
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

