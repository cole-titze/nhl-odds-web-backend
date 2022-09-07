using System;
using BusinessLogic.Mappers;
using DataAccess.PredictedGameRepository;
using Entities.DbModels;
using Entities.Models;

namespace BusinessLogic.Betting
{
    public class BettingCalculator : IBettingCalculator
    {
        private readonly IPredictedGameRepository _predictedGameRepository;

        public BettingCalculator(IPredictedGameRepository predictedGameRepository)
        {
            _predictedGameRepository = predictedGameRepository;
        }

        public async Task<IEnumerable<ModelBetResult>> CalculateBetOutcomes(int year, int numberOfGames, double betAmount)
        {
            var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
            var gameOddsData = PredictedGameToGameOddsDataMapper.Map(predictedGames);
            IEnumerable<ModelBetResult> betResults = CalculateBetResultsFromPredictions(gameOddsData, betAmount);
            return betResults;
        }
        private IEnumerable<ModelBetResult> CalculateBetResultsFromPredictions(GameOddsData gameOddsData, double betAmount)
        {
            double percentOdds = 0;
            var modelLogLosses = new List<ModelBetResult>();
            foreach (var key in gameOddsData.OddsMap.Keys)
            {
                double betResult = 0;
                for (int gameIndex = 0; gameIndex < gameOddsData.OddsMap[key].Count(); gameIndex++)
                {
                    var odds = gameOddsData.OddsMap[key][gameIndex];
                    var y = gameOddsData.TrueOutcomes[gameIndex];

                    if (LostBet(gameOddsData, gameIndex, y))
                    {
                        betResult -= betAmount;
                        continue;
                    }
                    if (SkipBet(gameOddsData, gameIndex))
                        continue;
                    if (IsHomeWin(y))
                        percentOdds = odds.HomeOdds;
                    else if (IsAwayWin(y))
                        percentOdds = odds.AwayOdds;

                    // Convert percentage to decimal odds and calculate winnings
                    betResult += (betAmount/percentOdds) - betAmount;
                }
                var modelLogLoss = new ModelBetResult()
                {
                    BetResult = betResult,
                    ModelOwner = key
                };
                modelLogLosses.Add(modelLogLoss);
            }
            return modelLogLosses;
        }
        private bool LostBet(GameOddsData gameOddsData, int gameIndex, WINNER y)
        {
            return (gameOddsData.homeModelOdds[gameIndex].HomeOdds >= .5 && y == WINNER.away) ||
                (gameOddsData.homeModelOdds[gameIndex].AwayOdds > .5 && y == WINNER.home);
        }
        private bool SkipBet(GameOddsData gameOddsData, int gameIndex)
        {
            return (gameOddsData.homeModelOdds[gameIndex].AwayOdds == 0 && gameOddsData.homeModelOdds[gameIndex].HomeOdds == 0);
        }
        private bool IsHomeWin(WINNER y)
        {
            return y == WINNER.home;
        }
        private bool IsAwayWin(WINNER y)
        {
            return y == WINNER.away;
        }


        public async Task<IEnumerable<ModelBetResult>> CalculateBetOutcomesOddsDifference(int year, int numberOfGames, double betAmount)
        {
            var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
            var gameOddsData = PredictedGameToGameOddsDataMapper.Map(predictedGames);
            IEnumerable<ModelBetResult> betResults = CalculateBetResultsFromPredictionsOddsDifference(gameOddsData, betAmount);
            return betResults;
        }
        private IEnumerable<ModelBetResult> CalculateBetResultsFromPredictionsOddsDifference(GameOddsData gameOddsData, double betAmount)
        {
            double percentOdds = 0;
            var modelLogLosses = new List<ModelBetResult>();
            foreach (var key in gameOddsData.OddsMap.Keys)
            {
                double betResult = 0;
                for (int gameIndex = 0; gameIndex < gameOddsData.OddsMap[key].Count(); gameIndex++)
                {
                    var odds = gameOddsData.OddsMap[key][gameIndex];
                    var y = gameOddsData.TrueOutcomes[gameIndex];

                    if (LostBetOddsDifference(gameOddsData, odds, gameIndex, y))
                    {
                        betResult -= betAmount;
                        continue;
                    }
                    if (SkipBet(gameOddsData, gameIndex))
                        continue;
                    if (IsHomeWin(y))
                        percentOdds = odds.HomeOdds;
                    else if (IsAwayWin(y))
                        percentOdds = odds.AwayOdds;

                    // Convert percentage to decimal odds and calculate winnings
                    betResult += (betAmount / percentOdds) - betAmount;
                }
                var modelLogLoss = new ModelBetResult()
                {
                    BetResult = betResult,
                    ModelOwner = key
                };
                modelLogLosses.Add(modelLogLoss);
            }
            return modelLogLosses;
        }
        private bool LostBetOddsDifference(GameOddsData gameOddsData, Odds vegasOdds, int gameIndex, WINNER y)
        {
            var myHomeOdds = gameOddsData.homeModelOdds[gameIndex].HomeOdds;
            var myAwayOdds = gameOddsData.homeModelOdds[gameIndex].AwayOdds;

            // Would assume this would help (pick what model predicts if relatively close to vegas, but its not
            //if (Math.Abs(vegasOdds.HomeOdds - myHomeOdds) < .03)
            //    return LostBet(gameOddsData, gameIndex, y);

            return ((myHomeOdds >= vegasOdds.HomeOdds) && (y == WINNER.away)) ||
                ((myAwayOdds > vegasOdds.AwayOdds) && (y == WINNER.home));
        }
    }
}

