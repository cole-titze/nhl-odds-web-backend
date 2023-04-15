using DataAccess.GameOddsRepository.Mappers;
using Entities.DbModels;
using FluentAssertions;

namespace DataAccessTests.UnitTests.Mappers
{
    [TestClass]
    public class DbGameOddsToGameOddsMapperUnitTests
    {
        [TestMethod]
        public void ACallToMap_WithNoDbGameOdds_ShouldGetNoGameOdds()
        {
            var dbGameOdds = new List<DbGameOdds>();
            var gameOdds = DbGameOddsToGameOddsMapper.Map(dbGameOdds);

            gameOdds.Should().HaveCount(0);
        }
        [TestMethod]
        public void ACallToMap_WithThreeDbGameOdds_ShouldGetThreeGameOdds()
        {
            var dbGameOdds = new List<DbGameOdds>()
            {
                new DbGameOdds(), new DbGameOdds(), new DbGameOdds()
            };
            var gameOdds = DbGameOddsToGameOddsMapper.Map(dbGameOdds);

            gameOdds.Should().HaveCount(3);
        }
        [TestMethod]
        public void ACallToMap_WithDbGameOdds_ShouldGetCorrectGameOdds()
        {
            var dbGameOdds = new List<DbGameOdds>()
            {
                new DbGameOdds()
                {
                    gameId = 1,
                    bovadaClosingVegasHomeOdds = .4,
                    bovadaClosingVegasAwayOdds = .6,
                    modelAwayOdds = .3,
                    modelHomeOdds = .7,
                    game = new DbGame()
                    {
                        id = 1,
                        gameDate = DateTime.Parse("01/15/2023"),
                        homeTeamId = 3,
                        awayTeamId = 9,
                        homeGoals = 3,
                        awayGoals = 4,
                        seasonStartYear = 2022,
                        winner = TEAM.away,
                        hasBeenPlayed = true,
                        homeTeam = new DbTeam(),
                        awayTeam = new DbTeam(),
                    }
                }
            };
            var gameOdds = DbGameOddsToGameOddsMapper.Map(dbGameOdds);

            gameOdds.Should().HaveCount(1);
            gameOdds.First().vegasHomeOdds.Should().Be(.4);
            gameOdds.First().vegasAwayOdds.Should().Be(.6);
            gameOdds.First().modelAwayOdds.Should().Be(.3);
            gameOdds.First().modelHomeOdds.Should().Be(.7);
            gameOdds.First().game.homeGoals.Should().Be(3);
            gameOdds.First().game.awayGoals.Should().Be(4);
        }
    }
}
