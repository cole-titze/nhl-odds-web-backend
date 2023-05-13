using DataAccess.TeamRepository;
using Entities.Types;

namespace BusinessLogicTests.Fakes
{
    public class FakeTeamRepository : ITeamRepository
	{
        private IEnumerable<TeamStats> _teams { get; set; } = new List<TeamStats>();
        public FakeTeamRepository(List<TeamStats> teams)
        {
            _teams = teams;
        }
        public Task<IEnumerable<TeamStats>> GetAllTeams()
        {
            return Task.FromResult(_teams);
        }

        public Task<TeamStats> GetTeam(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}

