namespace CarRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Car;

    public class Car
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(BrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }

        public bool IsPublic { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public int DealerId { get; init; }

        public Dealer Dealer { get; init; }
    }
}
