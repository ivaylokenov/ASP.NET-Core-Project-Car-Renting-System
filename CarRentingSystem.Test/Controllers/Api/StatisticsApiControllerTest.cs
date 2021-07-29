namespace CarRentingSystem.Test.Controllers.Api
{
    using CarRentingSystem.Controllers.Api;
    using CarRentingSystem.Test.Mocks;
    using Xunit;

    public class StatisticsApiControllerTest
    {
        [Fact]
        public void GetStatisticsShouldReturnTotalStatistics()
        {
            // Arrange
            var statisticsController = new StatisticsApiController(StatisticsServiceMock.Instance);

            // Act
            var result = statisticsController.GetStatistics();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.TotalCars);
            Assert.Equal(10, result.TotalRents);
            Assert.Equal(15, result.TotalUsers);
        }
    }
}
