using Entities.DbModels;
using FluentAssertions;

namespace EntitiesTests.DbModelsTests
{
    [TestClass]
    public class DbGameOddsTests
    {
        [TestMethod]
        public void PlaceholderDbGameOddsTest()
        {
            var dbGameOdds = new DbGameOdds()
            {
                gameId = 1,
                draftKingsHomeOdds = .4,
                draftKingsAwayOdds = .6,
                bovadaHomeOdds = .3,
                bovadaAwayOdds = .7,
                betMgmHomeOdds = .33,
                betMgmAwayOdds = .67,
                barstoolHomeOdds = .38,
                barstoolAwayOdds = .72,
                modelAwayOdds = .32,
                modelHomeOdds = .68,
            };

            dbGameOdds.betMgmAwayOdds.Should().Be(.67);
        }
    }
}
