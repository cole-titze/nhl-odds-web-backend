using Entities.DbModels;
using Entities.ViewModels;

namespace WebApi.Mappers
{
    public static class DbLogLossesToPointViewModel
    {
        public static LogLossPointVM Map(IEnumerable<DbLogLoss> dbLogLosses)
        {
            var logLossPoints = new LogLossPointVM();

            int count = 0;
            foreach(var dbLogLoss in dbLogLosses)
            {
                count++;
                if(count % 20 == 0 || count == dbLogLosses.Count())
                {
                    var games = dbLogLosses.Take(count);
                    logLossPoints.gameCounts.Add(count);
                    logLossPoints.modelLogLosses.Add(dbLogLosses.Select(x => x.modelLogLoss).Take(count).Average());
                    logLossPoints.barstoolLogLosses.Add(dbLogLosses.Select(x => x.barstoolLogLoss).Take(count).Average());
                    logLossPoints.betMgmLogLosses.Add(dbLogLosses.Select(x => x.betMgmLogLoss).Take(count).Average());
                    logLossPoints.bovadaLogLosses.Add(dbLogLosses.Select(x => x.bovadaLogLoss).Take(count).Average());
                    logLossPoints.draftKingsLogLosses.Add(dbLogLosses.Select(x => x.draftKingsLogLoss).Take(count).Average());
                }
            }

            return logLossPoints;
        }
    }
}
