using Entities.DbModels;
using Entities.ViewModels;
using FluentAssertions;

namespace EntitiesTests.ViewModelsTests
{
    [TestClass]
    public class GameOddsViewModelTests
    {
        [TestMethod]
        public void PlaceholderGameOddsViewModelTests()
        {
            var gameOddsViewModel = new GameOddsViewModel()
            {
                id = 1,
                gameDate = DateTime.Parse("01/15/2023"),
                homeTeam = new MatchupTeamViewModel(),
                awayTeam = new MatchupTeamViewModel(),
                winner = TEAM.away,
                hasBeenPlayed = false,
            };

            gameOddsViewModel.hasBeenPlayed.Should().Be(false);
        }
    }
}
