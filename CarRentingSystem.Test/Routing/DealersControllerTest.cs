namespace CarRentingSystem.Test.Routing
{
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Models.Dealers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Dealers/Become")
                .To<DealersController>(c => c.Become());

        [Fact]
        public void PostBecomeShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap(request => request
                    .WithPath("/Dealers/Become")
                    .WithMethod(HttpMethod.Post))
                .To<DealersController>(c => c.Become(With.Any<BecomeDealerFormModel>()));
    }
}
