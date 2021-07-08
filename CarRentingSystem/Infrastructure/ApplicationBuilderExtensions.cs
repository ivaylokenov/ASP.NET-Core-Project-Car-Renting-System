namespace CarRentingSystem.Infrastructure
{
    using System.Linq;
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<CarRentingDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(CarRentingDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Mini" },
                new Category { Name = "Economy" },
                new Category { Name = "Midsize" },
                new Category { Name = "Large" },
                new Category { Name = "SUV" },
                new Category { Name = "Vans" },
                new Category { Name = "Luxury" },
            });

            data.SaveChanges();
        }
    }
}
