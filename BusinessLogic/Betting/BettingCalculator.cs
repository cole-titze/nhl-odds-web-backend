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
                int gameIndex = 0;
                double betResult = 0;
                foreach (var odds in gameOddsData.OddsMap[key])
                {
                    // Remove once we add checking home model to repository
                    if (odds.AwayOdds == 0 || odds.HomeOdds == 0)
                        break;
                    var y = gameOddsData.TrueOutcomes[gameIndex];
                    if (LostBet(gameOddsData, gameIndex, y))
                        break;
                    if (IsHomeWin(y))
                        percentOdds = odds.HomeOdds;
                    else if (IsAwayWin(y))
                        percentOdds = odds.AwayOdds;

                    // Convert percentage to decimal odds and calculate winnings
                    betResult += (betAmount/percentOdds) - betAmount;
                    gameIndex++;
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
            return (gameOddsData.homeModelOdds[gameIndex].HomeOdds >= .5 && y == WINNER.away) || (gameOddsData.homeModelOdds[gameIndex].AwayOdds > .5 && y == WINNER.home);
        }
        private bool IsHomeWin(WINNER y)
        {
            return y == WINNER.home;
        }
        private bool IsAwayWin(WINNER y)
        {
            return y == WINNER.away;
        }
    }
}

