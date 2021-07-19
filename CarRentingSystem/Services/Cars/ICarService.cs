namespace CarRentingSystem.Services.Cars
{
    using System.Collections.Generic;
    using CarRentingSystem.Models;

    public interface ICarService
    {
        CarQueryServiceModel All(
            string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllCarBrands();
    }
}
