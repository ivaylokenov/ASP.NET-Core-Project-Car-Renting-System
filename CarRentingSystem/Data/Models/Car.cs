namespace CarRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Car
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }
    }
}
