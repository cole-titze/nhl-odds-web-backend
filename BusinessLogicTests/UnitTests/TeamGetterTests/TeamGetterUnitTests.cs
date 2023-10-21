namespace BusinessLogicTests.UnitTests.TeamGetterTests;
using FluentAssertions;
using BusinessLogic.TeamGetter;
using Entities.Types;
using Entities.DbModels;
using BusinessLogicTests.Fakes;

[TestClass]
public class TeamGetterUnitTests
{
    private const int YEAR = 2021;
    public List<TeamStats> TeamsFactory(int numberOfTeams)
    {
        var teamList = new List<TeamStats>();
        var logLossList = new List<DbLogLoss>();
        for (int i = 0; i < numberOfTeams; i++)
        {
            var team = new TeamStats()
            {
                team = new Team()
                {
                    id = i,
                }
            };
            teamList.Add(team);
        }
        return teamList;
    }
    public List<DbLogLoss> LogLossFactory(int numberOfLogLossGames, int numberOfteamsWhoPlayed)
    {
        var logLossList = new List<DbLogLoss>();
        for (int i = 0; i < numberOfLogLossGames; i++)
        {
            var logLoss = new DbLogLoss()
            {
                game = new DbGame()
                {
                    homeTeamId = i % numberOfteamsWhoPlayed,
                    awayTeamId = (i + 1) % numberOfteamsWhoPlayed,
                    seasonStartYear = YEAR
                }
            };
            logLossList.Add(logLoss);
        }
        return logLossList;
    }
    public TeamGetter Factory(int numberOfTeams, int numberOfLogLossGames, int numberOfTeamsWhoPlayed)
    {
        var teamList = TeamsFactory(numberOfTeams);
        var logLossList = LogLossFactory(numberOfLogLossGames, numberOfTeamsWhoPlayed);
        var teamRepo = new FakeTeamRepository(teamList);
        var logLossRepo = new FakeLogLossRepository(logLossList);

        var cut = new TeamGetter(teamRepo, logLossRepo);

        return cut;
    }
    [TestMethod]
    public async Task CallToBuildTeamLogLosses_WithZeroTeamsAndZeroLogLosses_ShouldGetZeroTeams()
    {
        int numberOfTeams = 0;
        int numberOfLogLossGames = 0;
        var cut = Factory(numberOfTeams, numberOfLogLossGames, 1);

        var teams = await cut.GetAllTeamsStats(YEAR);
        teams.Should().HaveCount(0);
    }
    [TestMethod]
    public async Task CallToBuildTeamLogLosses_WithZeroTeamsAndFiveLogLosses_ShouldGetZeroTeams()
    {
        int numberOfTeams = 0;
        int numberOfLogLossGames = 5;
        var cut = Factory(numberOfTeams, numberOfLogLossGames, 1);

        var teams = await cut.GetAllTeamsStats(YEAR);
        teams.Should().HaveCount(0);
    }
    [TestMethod]
    public async Task CallToBuildTeamLogLosses_WithFiveTeamsAndZeroLogLosses_ShouldGetZeroTeams()
    {
        int numberOfTeams = 5;
        int numberOfLogLossGames = 0;
        var cut = Factory(numberOfTeams, numberOfLogLossGames, 1);

        var teams = await cut.GetAllTeamsStats(YEAR);
        teams.Should().HaveCount(0);
    }
    [TestMethod]
    public async Task CallToBuildTeamLogLosses_WithFiveTeamsAndTenLogLossesForThreeTeamsWhoPlayed_ShouldGetThreeTeams()
    {
        int numberOfTeamsWhoPlayed = 3;
        int numberOfTeams = 5;
        int numberOfLogLossGames = 10;
        var cut = Factory(numberOfTeams, numberOfLogLossGames, numberOfTeamsWhoPlayed);

        var teams = await cut.GetAllTeamsStats(YEAR);
        teams.Should().HaveCount(3);
    }
    private List<DbLogLoss> BuildLogLossValues(List<DbLogLoss> logLossList)
    {
        logLossList[0].modelLogLoss = .854;
        logLossList[1].modelLogLoss = .764;
        logLossList[2].modelLogLoss = .812;
        logLossList[3].modelLogLoss = .943;
        logLossList[4].modelLogLoss = .567;
        logLossList[5].modelLogLoss = .654;
        logLossList[0].draftKingsLogLoss = .677;
        logLossList[1].draftKingsLogLoss = .756;
        logLossList[2].draftKingsLogLoss = .777;
        logLossList[3].draftKingsLogLoss = .698;
        logLossList[4].draftKingsLogLoss = .843;
        logLossList[5].draftKingsLogLoss = .722;

        return logLossList;
    }
    [TestMethod]
    public async Task CallToBuildTeamLogLosses_WithOneTeamWhoPlayedAndSetGameLogLosses_ShouldGetOneTeamWithCorrectLogLoss()
    {
        int numberOfTeamsWhoPlayed = 1;
        int numberOfTeams = 1;
        int numberOfLogLossGames = 6;
        var teamList = TeamsFactory(numberOfTeams);
        var logLossList = LogLossFactory(numberOfLogLossGames, numberOfTeamsWhoPlayed);
        logLossList = BuildLogLossValues(logLossList);
        
        var teamRepo = new FakeTeamRepository(teamList);
        var logLossRepo = new FakeLogLossRepository(logLossList);
        var cut = new TeamGetter(teamRepo, logLossRepo);

        var teams = await cut.GetAllTeamsStats(YEAR);
        Math.Round(teams.First().modelLogLoss, 4).Should().Be(.7657);
        Math.Round(teams.First().vegasLogLoss, 4).Should().Be(.7455);
    }
}
