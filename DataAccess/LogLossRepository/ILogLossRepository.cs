using System;
using Entities.DbModels;

namespace DataAccess.LogLossRepository
{
	public interface ILogLossRepository
	{
        Task<IEnumerable<DbLogLoss>> GetAllLogLossesForSeason(int seasonStartYear);
    }
}
