using BusinessLogic.Mappers;
using DataAccess.PredictedGameRepository;
using Entities.Models;

namespace BusinessLogic.LogLoss;
public class LogLossCalculator : ILogLossCalculator
{
    private readonly IPredictedGameRepository _predictedGameRepository;

    public LogLossCalculator(IPredictedGameRepository predictedGameRepository)
    {
        _predictedGameRepository = predictedGameRepository;
    }

    public async Task<IEnumerable<ModelLogLoss>> CalculateLogLossesForYearAndNumberOfGames(int year, int numberOfGames)
    {
        var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
        var logLossData = PredictedGameToGameOddsDataMapper.Map(predictedGames);
        IEnumerable<ModelLogLoss> logLosses = CalculateLogLossFromPredictions(logLossData);
        return logLosses;
    }

    private IEnumerable<ModelLogLoss> CalculateLogLossFromPredictions(GameOddsData logLossData)
    {
        var modelLogLosses = new List<ModelLogLoss>();
        foreach(var key in logLossData.OddsMap.Keys)
        {
            int gameIndex = 0;
            double logLoss = 0;
            foreach(var odds in logLossData.OddsMap[key])
            {
                // Remove once we add checking home model to repository
                if (odds.AwayOdds == 0 || odds.HomeOdds == 0)
                    break;
                var y = logLossData.TrueOutcomes[gameIndex];
                logLoss += -(((int)y)*Math.Log(odds.HomeOdds) + (1-((int)y))*Math.Log(1-odds.AwayOdds));
                gameIndex++;
            }
            logLoss = logLoss / logLossData.OddsMap[key].Count;
            var modelLogLoss = new ModelLogLoss()
            {
                LogLoss = logLoss,
                ModelOwner = key
            };
            modelLogLosses.Add(modelLogLoss);
        }
        return modelLogLosses;
    }
}

