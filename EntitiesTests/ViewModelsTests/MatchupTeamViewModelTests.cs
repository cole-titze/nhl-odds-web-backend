using Entities.ViewModels;
using Entities.DbModels;
using FluentAssertions;

namespace EntitiesTests.ViewModelsTests
{
    [TestClass]
    public class MatchupTeamViewModelTests
    {
        [TestMethod]
        public void PlaceholderMatchupTeamViewModelTests()
        {
            var matchupTeamViewModel = new MatchupTeamVM()
            {
                id = 1,
                locationName = "tor",
                teamName = "leafs",
                logoUri = "www",
                modelOdds = .6,
                vegasOdds = .55,
                goals = 3,
                team = TEAM.away,
            };

            matchupTeamViewModel.vegasOdds.Should().Be(.55);
        }
    }
}