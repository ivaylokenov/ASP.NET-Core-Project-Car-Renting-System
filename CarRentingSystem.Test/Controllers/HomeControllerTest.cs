namespace CarRentingSystem.Test.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarRentingSystem.Controllers;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Services.Statistics;
    using CarRentingSystem.Test.Mocks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
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
                    .WithModelOfType<IndexViewModel>()
                    .Passing(m => m.Cars.Should().HaveCount(3)));

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            // Arrange
            var data = DatabaseMock.Instance;
            var mapper = MapperMock.Instance;

            var cars = Enumerable
                .Range(0, 10)
                .Select(i => new Car());

            data.Cars.AddRange(cars);
            data.Users.Add(new User());

            data.SaveChanges();

            var carService = new CarService(data, mapper);
            var statisticsService = new StatisticsService(data);

            var homeController = new HomeController(carService, statisticsService);

            // Act
            var result = homeController.Index();

            // Assert
            // Assert.NotNull(result);

            // var viewResult = Assert.IsType<ViewResult>(result);

            // var model = viewResult.Model;

            // var indexViewModel = Assert.IsType<IndexViewModel>(model);

            // Assert.Equal(3, indexViewModel.Cars.Count);
            // Assert.Equal(10, indexViewModel.TotalCars);
            // Assert.Equal(1, indexViewModel.TotalUsers);

            result
                .Should()
                .NotBeNull()
                .And
                .BeAssignableTo<ViewResult>()
                .Which
                .Model
                .As<IndexViewModel>()
                .Invoking(model =>
                {
                    model.Cars.Should().HaveCount(3);
                    model.TotalCars.Should().Be(10);
                    model.TotalUsers.Should().Be(1);
                })
                .Invoke();
        }

        [Fact]
        public void ErrorShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController(
                null, 
                null);

            // Act
            var result = homeController.Error();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        private static IEnumerable<Car> GetCars()
            => Enumerable.Range(0, 10).Select(i => new Car());
    }
}
