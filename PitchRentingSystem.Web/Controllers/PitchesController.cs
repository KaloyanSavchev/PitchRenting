using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Models.Pitches;

namespace PitchRentingSystem.Web.Controllers
{
    public class PitchesController : Controller
    {
        public IActionResult All()
        {
            var allPitches = new AllPitchesViewModel()
            {
                Pitches = Common.GetPitches()
            };
            return View(allPitches);
        }

        public IActionResult Details()
        {
            var pitches  = Common.GetPitches().FirstOrDefault();
            return View(pitches);
        }
    }
}
