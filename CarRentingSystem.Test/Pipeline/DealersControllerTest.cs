namespace CarRentingSystem.Test.Pipeline
{
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Models.Dealers;
    using MyTested.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;

    using static WebConstants;

    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Dealers/Become")
                    .WithUser())
                .To<DealersController>(c => c.Become())
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();

        [Theory]
        [InlineData("Dealer", "+359888888888")]
        public void PostBecomeShouldBeForAuthorizedUsersAndReturnRedirectWithValidModel(
            string dealerName,
            string phoneNumber)
            => MyPipeline
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Dealers/Become")
                    .WithMethod(HttpMethod.Post)
                    .WithFormFields(new
                    {
                        Name = dealerName,
                        PhoneNumber = phoneNumber
                    })
                    .WithUser()
                    .WithAntiForgeryToken())
                .To<DealersController>(c => c.Become(new BecomeDealerFormModel
                {
                    Name = dealerName,
                    PhoneNumber = phoneNumber
                }))
                .Which()
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .RestrictingForAuthorizedRequests())
                .ValidModelState()
                .Data(data => data
                    .WithSet<Dealer>(dealers => dealers
                        .Any(d =>
                            d.Name == dealerName &&
                            d.PhoneNumber == phoneNumber &&
                            d.UserId == TestUser.Identifier)))
                .TempData(tempData => tempData
                    .ContainingEntryWithKey(GlobalMessageKey))
                .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<CarsController>(c => c.All(With.Any<AllCarsQueryModel>())));
    }
}
