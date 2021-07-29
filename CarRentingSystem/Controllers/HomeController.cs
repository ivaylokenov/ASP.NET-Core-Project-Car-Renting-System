namespace CarRentingSystem.Controllers
{
    using System.Linq;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICarService cars;
        private readonly IStatisticsService statistics;

        public HomeController(
            ICarService cars,
            IStatisticsService statistics)
        {
            this.cars = cars;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {
            var latestCars = this.cars
                .Latest()
                .ToList();

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalCars = totalStatistics.TotalCars,
                TotalUsers = totalStatistics.TotalUsers,
                Cars = latestCars
            });
        }

        public IActionResult Error() => View();
    }
}
