using System.ComponentModel;

namespace PitchRentingSystem.Web.Models.Pitches
{
    public class PitchViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        public string Description { get; set; } = null!;

        [DisplayName("Imgae Url")]
        public string ImageUrl { get; init; } = null!;

        [DisplayName("Price Per Rent")]
        public decimal PricePerRent { get; init; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; init; }


    }
}
