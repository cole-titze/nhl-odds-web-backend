using Entities.DbModels;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class DbLogLossesToViewModel
    {
        public static IEnumerable<LogLossVM> Map(IEnumerable<DbLogLoss> dbLogLosses)
        {
            var logLosses = new List<LogLossVM>();

            foreach (var dbLogLoss in dbLogLosses)
            {
                logLosses.Add(new LogLossVM
                {
                    gameId = dbLogLoss.gameId,
                    draftKingsLogLoss = dbLogLoss.draftKingsLogLoss,
                    bovadaLogLoss = dbLogLoss.bovadaLogLoss,
                    betMgmLogLoss = dbLogLoss.betMgmLogLoss,
                    barstoolLogLoss = dbLogLoss.barstoolLogLoss,
                    modelLogLoss = dbLogLoss.modelLogLoss,
                    gameDate = dbLogLoss.game.gameDate,
                });
            }

            return logLosses;
        }
    }
}
