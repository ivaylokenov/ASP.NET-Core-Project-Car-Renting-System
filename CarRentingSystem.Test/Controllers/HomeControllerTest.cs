namespace CarRentingSystem.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Services.Cars.Models;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnViewWithCorrectModelAndData()
            => MyMvc
                .Pipeline()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index())
                .Which(controller => controller
                    .WithData(GetCars()))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<List<LatestCarServiceModel>>()
                    .Passing(m => m.Should().HaveCount(3)));

        private static IEnumerable<Car> GetCars()
            => Enumerable.Range(0, 10).Select(i => new Car());
    }
}
