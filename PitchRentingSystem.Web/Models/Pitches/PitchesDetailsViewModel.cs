using System.ComponentModel;

namespace PitchRentingSystem.Web.Models.Pitches
{
    public class PitchesDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Description { get; init; } = null!;

        public bool IsRented { get; set; }

        [DisplayName("Price Per Rent")]
        public decimal PricePerRent { get; init; }

       
    }
}
