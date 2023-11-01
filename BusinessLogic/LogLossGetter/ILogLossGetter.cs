using Entities.DbModels;

namespace BusinessLogic.LogLossGetter
{
    public interface ILogLossGetter
    {
        Task<IEnumerable<DbLogLoss>> GetLogLosses(int seasonStartYear, int? teamId);
    }
}
