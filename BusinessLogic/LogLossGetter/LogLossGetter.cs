using DataAccess.LogLossRepository;
using Entities.DbModels;

namespace BusinessLogic.LogLossGetter
{
    public class LogLossGetter : ILogLossGetter
    {
        private readonly ILogLossRepository _logLossRepo;
        public LogLossGetter(ILogLossRepository logLossRepo)
        {
            _logLossRepo = logLossRepo;
        }
        /// <summary>
        /// Gets log losses for the given year and team
        /// </summary>
        /// <param name="seasonStartYear">Season to get log losses for</param>
        /// <param name="teamId">Team to get log losses for</param>
        /// <returns>List of log losses</returns>
        public async Task<IEnumerable<DbLogLoss>> GetLogLosses(int seasonStartYear, int? teamId)
        {
            var logLosses = await _logLossRepo.GetAllLogLossesForSeason(seasonStartYear);
            if(teamId == null)
                return logLosses;

            return logLosses.Where(g => g.game.awayTeamId == teamId || g.game.homeTeamId == teamId);
        }
    }
}
