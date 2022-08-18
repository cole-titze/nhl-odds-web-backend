using System;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.Mappers
{
    public static class PredictedGameToLogLossDataMapper
    {
        public static LogLossData Map(IEnumerable<DbPredictedGame> predictedGames)
        {
            var gameWinners = new List<int>();
            var odds = new Odds();
            var oddsMap = new Dictionary<string, List<Odds>>();
            oddsMap.Add("HomeModel", new List<Odds>());
            oddsMap.Add("VegasModel", new List<Odds>());

            foreach (var game in predictedGames)
            {
                odds.HomeOdds = game.modelHomeOdds;
                odds.AwayOdds = game.modelAwayOdds;
                oddsMap["HomeModel"].Add(odds);

                odds.HomeOdds = game.vegasHomeOdds;
                odds.AwayOdds = game.vegasAwayOdds;
                oddsMap["VegasModel"].Add(odds);

                gameWinners.Add(game.winner);
            }

            return new LogLossData()
            {
                OddsMap = oddsMap,
                TrueOutcomes = gameWinners
            };
        }
    }
}

