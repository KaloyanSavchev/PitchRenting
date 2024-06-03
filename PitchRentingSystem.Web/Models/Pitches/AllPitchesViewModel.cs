namespace PitchRentingSystem.Web.Models.Pitches
{
    public class AllPitchesViewModel
    {
        public IEnumerable<PitchesDetailsViewModel> Pitches { get; set; }
            = new List<PitchesDetailsViewModel>();
    }
}
