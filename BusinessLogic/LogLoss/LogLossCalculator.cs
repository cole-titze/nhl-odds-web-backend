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
        // Must get correct outcomes of each match then calculate logloss
        var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
        var logLossData = PredictedGameToLogLossDataMapper.Map(predictedGames);
        IEnumerable<ModelLogLoss> logLosses = CalculateLogLossFromPredictions(logLossData);
        return logLosses;
    }

    private IEnumerable<ModelLogLoss> CalculateLogLossFromPredictions(LogLossData logLossData)
    {
        var modelLogLosses = new List<ModelLogLoss>();
        foreach(var key in logLossData.OddsMap.Keys)
        {
            int gameIndex = 0;
            double logLoss = 0;
            foreach(var odds in logLossData.OddsMap[key])
            {
                var y = logLossData.TrueOutcomes[gameIndex];
                logLoss += -(y*Math.Log(odds.HomeOdds) + (1-y)*Math.Log(1-odds.AwayOdds));
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

