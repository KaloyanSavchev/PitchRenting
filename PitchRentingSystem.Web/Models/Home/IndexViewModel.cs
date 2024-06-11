using PitchRentingSystem.Web.Models.Pitches;

namespace PitchRentingSystem.Web.Models.Home
{
    public class IndexViewModel
    {
        public int TotalPitches { get; set; }
        public int TotalRents { get; set; }

        public IEnumerable<PitchIndexViewModel> Pitches { get; set; }
            = new List<PitchIndexViewModel>();
    }
}
