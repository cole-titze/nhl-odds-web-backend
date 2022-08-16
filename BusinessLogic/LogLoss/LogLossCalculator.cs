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

    public async Task<IEnumerable<ModelLogLoss>> CalculateLogLossForYearAndNumberOfGames(int year, int numberOfGames)
    {
        IEnumerable<ModelLogLoss> temp = new List<ModelLogLoss>();
        // Must get correct outcomes of each match then calculate logloss
        var predictedGames = await _predictedGameRepository.GetFirstPredictedGamesOfYear(year, numberOfGames);
        return temp;
    }
}

