using System;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.Mappers
{
    public static class PredictedGameToGameOddsDataMapper
    {
        public static GameOddsData Map(IEnumerable<DbPredictedGame> predictedGames)
        {
            var homeModelOdds = new List<Odds>();
            var gameWinners = new List<TEAM>();
            var oddsMap = new Dictionary<string, List<Odds>>();
            oddsMap.Add("BovadaClosingVegasModel", new List<Odds>());
            oddsMap.Add("BovadaOpeningVegasModel", new List<Odds>());
            oddsMap.Add("MyBookieClosingVegasModel", new List<Odds>());
            oddsMap.Add("MyBookieOpeningVegasModel", new List<Odds>());
            oddsMap.Add("PinnacleClosingVegasModel", new List<Odds>());
            oddsMap.Add("PinnacleOpeningVegasModel", new List<Odds>());
            oddsMap.Add("BetOnlineClosingVegasModel", new List<Odds>());
            oddsMap.Add("BetOnlineOpeningVegasModel", new List<Odds>());
            oddsMap.Add("Bet365ClosingVegasModel", new List<Odds>());
            oddsMap.Add("Bet365OpeningVegasModel", new List<Odds>());


            foreach (var game in predictedGames)
            {
                var odds = new Odds()
                {
                    HomeOdds = game.modelHomeOdds,
                    AwayOdds = game.modelAwayOdds,
                };
                homeModelOdds.Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.bovadaClosingVegasHomeOdds,
                    AwayOdds = game.bovadaClosingVegasAwayOdds,
                };
                oddsMap["BovadaClosingVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.bovadaOpeningVegasHomeOdds,
                    AwayOdds = game.bovadaOpeningVegasAwayOdds,
                };
                oddsMap["BovadaOpeningVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.myBookieClosingVegasHomeOdds,
                    AwayOdds = game.myBookieClosingVegasAwayOdds,
                };
                oddsMap["MyBookieClosingVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.myBookieOpeningVegasHomeOdds,
                    AwayOdds = game.myBookieOpeningVegasAwayOdds,
                };
                oddsMap["MyBookieOpeningVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.pinnacleClosingVegasHomeOdds,
                    AwayOdds = game.pinnacleClosingVegasAwayOdds,
                };
                oddsMap["PinnacleClosingVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.pinnacleOpeningVegasHomeOdds,
                    AwayOdds = game.pinnacleOpeningVegasAwayOdds,
                };
                oddsMap["PinnacleOpeningVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.betOnlineClosingVegasHomeOdds,
                    AwayOdds = game.betOnlineClosingVegasAwayOdds,
                };
                oddsMap["BetOnlineClosingVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.betOnlineOpeningVegasHomeOdds,
                    AwayOdds = game.betOnlineOpeningVegasAwayOdds,
                };
                oddsMap["BetOnlineOpeningVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.bet365ClosingVegasHomeOdds,
                    AwayOdds = game.bet365ClosingVegasAwayOdds,
                };
                oddsMap["Bet365ClosingVegasModel"].Add(odds);

                odds = new Odds
                {
                    HomeOdds = game.bet365OpeningVegasHomeOdds,
                    AwayOdds = game.bet365OpeningVegasAwayOdds,
                };
                oddsMap["Bet365OpeningVegasModel"].Add(odds);

                gameWinners.Add(game.cleanedGame.winner);
            }

            return new GameOddsData()
            {
                OddsMap = oddsMap,
                TrueOutcomes = gameWinners,
                homeModelOdds = homeModelOdds
            };
        }
    }
}

