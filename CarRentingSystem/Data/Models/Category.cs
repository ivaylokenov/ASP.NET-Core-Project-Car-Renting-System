namespace CarRentingSystem.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}
