using System;
using BusinessLogic.Mappers;
using DataAccess.PredictedGameRepository;
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

        public async Task<IEnumerable<ModelBetResult>> CalculateBetOutcomes(int year, int numberOfGames, decimal betAmount)
        {
            // Must get correct outcomes of each match then calculate logloss
            var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
            var gameOddsData = PredictedGameToGameOddsDataMapper.Map(predictedGames);
            IEnumerable<ModelBetResult> betResults = CalculateBetResultsFromPredictions(gameOddsData, betAmount);
            return betResults;
        }
        // 0 win is away, 1 win is home
        // TODO: Make enum
        private IEnumerable<ModelBetResult> CalculateBetResultsFromPredictions(GameOddsData gameOddsData, decimal betAmount)
        {
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
                    if ((gameOddsData.homeModelOdds[gameIndex].HomeOdds >= .5 && y == 0) || (gameOddsData.homeModelOdds[gameIndex].AwayOdds > .5 && y == 1))
                        break;
                    betResult += Convert.ToDouble((betAmount * 1) - betAmount); // TODO: Won bet, calculate money gained
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
    }
}

