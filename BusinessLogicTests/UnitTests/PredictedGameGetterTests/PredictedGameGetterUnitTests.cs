namespace BusinessLogicTests.UnitTests.TeamGetterTests;
using FluentAssertions;
using Entities.Types;
using Entities.DbModels;
using BusinessLogic.GameOddsGetter;
using BusinessLogicTests.Fakes;

[TestClass]
public class GameOddsGetterUnitTests
{
    private DateRange dateRange = new DateRange()
    {
        startDate = DateTime.Parse("1/1/2000"),
        endDate = DateTime.Parse("1/1/2010")
    };
    private DateTime dateInRange = DateTime.Parse("1/1/2005");
    private DateTime dateOutOfRange = DateTime.Parse("1/1/2020");
    public List<GameOdds> GamesFactory(int numberOfGamesInDateRange, int numberOfGamesOutOfDateRange)
    {
        var gameList = new List<GameOdds>();
        for (int i = 0; i < numberOfGamesInDateRange; i++)
        {
            var game = new GameOdds()
            {
                game = new Game()
                {
                    gameDate = dateInRange
                }
            };
            gameList.Add(game);
        }
        for (int i = 0; i < numberOfGamesOutOfDateRange; i++)
        {
            var game = new GameOdds()
            {
                game = new Game()
                {
                    gameDate = dateOutOfRange
                }
            };
            gameList.Add(game);
        }
        return gameList;
    }
    public GameOddsGetter Factory(int numberOfGamesInDateRange, int numberOfGamesOutOfDateRange)
    {
        var gameList = GamesFactory(numberOfGamesInDateRange, numberOfGamesOutOfDateRange);
        var gameRepo = new FakeGameOddsRepository(gameList);

        var cut = new GameOddsGetter(gameRepo);

        return cut;
    }
    [TestMethod]
    public async Task CallToGetPredictedGamesInDateRange_WithNoGamesInDateRange_ShouldGetNoGames()
    {
        int numberOfGamesInDateRange = 0;
        int numberOfGamesOutOfDateRange = 5;
        var cut = Factory(numberOfGamesInDateRange, numberOfGamesOutOfDateRange);

        var games = await cut.GetGameOddsInDateRange(dateRange);
        games.Should().HaveCount(0);
    }
    [TestMethod]
    public async Task CallToGetPredictedGamesInDateRange_WithFiveGamesInDateRange_ShouldGetFiveGames()
    {
        int numberOfGamesInDateRange = 5;
        int numberOfGamesOutOfDateRange = 0;
        var cut = Factory(numberOfGamesInDateRange, numberOfGamesOutOfDateRange);

        var games = await cut.GetGameOddsInDateRange(dateRange);
        games.Should().HaveCount(5);
    }
    [TestMethod]
    public async Task CallToGetPredictedGamesInDateRange_WithFiveGamesInDateRangeAndFiftyGamesOutOfDateRange_ShouldGetFiveGames()
    {
        int numberOfGamesInDateRange = 5;
        int numberOfGamesOutOfDateRange = 50;
        var cut = Factory(numberOfGamesInDateRange, numberOfGamesOutOfDateRange);

        var games = await cut.GetGameOddsInDateRange(dateRange);
        games.Should().HaveCount(5);
    }
    [TestMethod]
    public async Task CallToGetPredictedGamesInDateRange_WitZeroGamesInDateRangeAndZeroGamesOutOfDateRange_ShouldGetZeroGames()
    {
        int numberOfGamesInDateRange = 0;
        int numberOfGamesOutOfDateRange = 0;
        var cut = Factory(numberOfGamesInDateRange, numberOfGamesOutOfDateRange);

        var games = await cut.GetGameOddsInDateRange(dateRange);
        games.Should().HaveCount(0);
    }
}

