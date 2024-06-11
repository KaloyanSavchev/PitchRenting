using System.ComponentModel;

namespace PitchRentingSystem.Web.Models.Pitches
{
    public class AllPitchesQueryModel
    {
        public IEnumerable<PitchesDetailsViewModel> Pitches { get; set; }
            = new List<PitchesDetailsViewModel>();

        /*public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        [DisplayName("Imgae Url")]
        public string ImageUrl { get; init; } = null!;

        [DisplayName("Price Per Rent")]
        public decimal PricePerRent { get; init; }

        [DisplayName("Is Rented")]
        public bool IsRented { get; init; }*/

        /*  public const int PitchesPerPage = 3;
          public IEnumerable<PitchViewModel> Pitches { get; set; } = new List<PitchViewModel>();
          public string Category { get; init; } = null!;

          [DisplayName("Search by text")]
          public string SearchTerm { get; init; } = null!;

          public PitchSorting Sorting { get; init; }

          public int CurrentPage { get; init; } = 1;

          public int TotalPitchesCount { get; set; }

          public IEnumerable<string> Categories { get; set; } = new List<string>();*/

    }
}
