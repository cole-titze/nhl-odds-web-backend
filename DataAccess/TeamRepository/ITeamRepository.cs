using System;
using Entities.Models;

namespace DataAccess.TeamRepository
{
	public interface ITeamRepository
	{
        Task<IEnumerable<Team>> GetAllTeams();
    }
}

