using Entities.DbModels;
using FluentAssertions;

namespace EntitiesTests.DbModelsTests
{
    [TestClass]
    public class DbLogLossTests
    {
        [TestMethod]
        public void PlaceholderDbLogLossTests()
        {
            var dbLogLosses = new DbLogLoss()
            {
                gameId = 1,
                draftKingsLogLoss = .67,
                modelLogLoss = .33,
                game = new DbGame(),
            };

            dbLogLosses.modelLogLoss.Should().Be(.33);
        }
    }
}
