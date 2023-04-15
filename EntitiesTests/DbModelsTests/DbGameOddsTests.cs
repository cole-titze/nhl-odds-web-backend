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
                bovadaClosingVegasAwayOdds = .4,
                bovadaClosingVegasHomeOdds = .6,
                myBookieClosingVegasAwayOdds = .3,
                myBookieClosingVegasHomeOdds = .7,
                pinnacleClosingVegasAwayOdds = .33,
                pinnacleClosingVegasHomeOdds = .67,
                betOnlineClosingVegasAwayOdds = .4,
                betOnlineClosingVegasHomeOdds = .6,
                bet365ClosingVegasAwayOdds = .8,
                bet365ClosingVegasHomeOdds = .2,
                bovadaOpeningVegasAwayOdds = .25,
                bovadaOpeningVegasHomeOdds = .75,
                myBookieOpeningVegasAwayOdds = .44,
                myBookieOpeningVegasHomeOdds = .56,
                pinnacleOpeningVegasAwayOdds = .13,
                pinnacleOpeningVegasHomeOdds = .87,
                betOnlineOpeningVegasAwayOdds = .22,
                betOnlineOpeningVegasHomeOdds = .78,
                bet365OpeningVegasAwayOdds = .44,
                bet365OpeningVegasHomeOdds = .56,
                modelAwayOdds = .32,
                modelHomeOdds = .68,
            };

            dbGameOdds.pinnacleOpeningVegasHomeOdds.Should().Be(.87);
        }
    }
}
