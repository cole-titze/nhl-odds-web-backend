using System;
using DataAccess.TeamRepository;
using Entities.Models;

namespace BusinessLogicUnitTests.Fakes
{
	public class FakeTeamRepository : ITeamRepository
	{
        private IList<Team> _teams { get; set; } = new List<Team>();
        public FakeTeamRepository(List<Team> teams)
        {
            _teams = teams;
        }
        public Task<IList<Team>> GetAllTeams()
        {
            return Task.FromResult(_teams);
        }
    }
}

