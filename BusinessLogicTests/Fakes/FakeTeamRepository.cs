using DataAccess.TeamRepository;
using Entities.Models;

namespace BusinessLogicTests.Fakes
{
    public class FakeTeamRepository : ITeamRepository
	{
        private IList<TeamStats> _teams { get; set; } = new List<TeamStats>();
        public FakeTeamRepository(List<TeamStats> teams)
        {
            _teams = teams;
        }
        public Task<IList<TeamStats>> GetAllTeams()
        {
            return Task.FromResult(_teams);
        }
    }
}

