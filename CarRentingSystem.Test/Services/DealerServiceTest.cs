namespace CarRentingSystem.Test.Services
{
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Dealers;
    using CarRentingSystem.Test.Mocks;
    using Xunit;
    
    public class DealerServiceTest
    {
        private const string UserId = "TestUserId";

        [Fact]
        public void IsDealerShouldReturnTrueWhenUserIsDealer()
        {
            // Arrange
            var dealerService = GetDealerService();

            // Act
            var result = dealerService.IsDealer(UserId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDealerShouldReturnFalseWhenUSerIsNotDealer()
        {
            // Arrange
            var dealerService = GetDealerService();

            // Act
            var result = dealerService.IsDealer("AnotherUserId");

            // Assert
            Assert.False(result);
        }

        private static IDealerService GetDealerService()
        {
            var data = DatabaseMock.Instance;

            data.Dealers.Add(new Dealer { UserId = UserId });
            data.SaveChanges();

            return new DealerService(data);
        }
    }
}
