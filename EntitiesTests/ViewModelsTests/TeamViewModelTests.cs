using Entities.ViewModels;
using Entities.DbModels;
using FluentAssertions;

namespace EntitiesTests.ViewModelsTests
{
    [TestClass]
    public class TeamViewModelTests
    {
        [TestMethod]
        public void PlaceholderTeamViewModelTests()
        {
            var teamViewModel = new TeamVM()
            {
                id = 1,
                locationName = "tor",
                teamName = "leafs",
                logoUri = "www",
                vegasLogLoss = .6,
                modelLogLoss = .55,
            };

            teamViewModel.modelLogLoss.Should().Be(.55);
        }
    }
}