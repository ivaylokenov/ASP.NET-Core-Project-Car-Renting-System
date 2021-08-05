namespace CarRentingSystem.Areas.Admin.Controllers
{
    using CarRentingSystem.Services.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : AdminController
    {
        private readonly ICarService cars;

        public CarsController(ICarService cars) => this.cars = cars;

        public IActionResult All()
        {
            var cars = this.cars
                .All(publicOnly: false)
                .Cars;

            return View(cars);
        }

        public IActionResult ChangeVisibility(int id)
        {
            this.cars.ChangeVisility(id);

            return RedirectToAction(nameof(All));
        }
    }
}
