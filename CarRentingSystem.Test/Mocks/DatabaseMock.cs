namespace CarRentingSystem.Test.Mocks
{
    using System;
    using CarRentingSystem.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DatabaseMock
    {
        public static CarRentingDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CarRentingDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new CarRentingDbContext(dbContextOptions);
            }
        }
    }
}
