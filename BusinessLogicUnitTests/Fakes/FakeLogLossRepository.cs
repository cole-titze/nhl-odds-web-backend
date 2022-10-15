using System;
using DataAccess.LogLossRepository;
using Entities.DbModels;

namespace BusinessLogicTests.Fakes
{
    public class FakeLogLossRepository : ILogLossRepository
    {
        private IList<DbLogLoss> _logLosses = new List<DbLogLoss>();
        public FakeLogLossRepository(List<DbLogLoss> logLosses)
        {
            _logLosses = logLosses;
        }
        public async Task<IEnumerable<DbLogLoss>> GetAllLogLossesForSeason(int seasonStartYear)
        {
            return await Task.FromResult(_logLosses);
        }
    }
}

