namespace CarRentingSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarRentingSystem.Services.Cars;
    using CarRentingSystem.Services.Cars.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using static WebConstants.Cache;

    public class HomeController : Controller
    {
        private readonly ICarService cars;
        private readonly IMemoryCache cache;

        public HomeController(
            ICarService cars,
            IMemoryCache cache)
        {
            this.cars = cars;
            this.cache = cache;
        }
        
        public IActionResult Index()
        {
            var latestCars = this.cache.Get<List<LatestCarServiceModel>>(LatestCarsCacheKey);

            if (latestCars == null)
            {
                latestCars = this.cars
                   .Latest()
                   .ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(LatestCarsCacheKey, latestCars, cacheOptions);
            }

            return View(latestCars);
        }

        public IActionResult Error() => View();
    }
}
