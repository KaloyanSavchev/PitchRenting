using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Models.Pitches;
using System.Security.Claims;

namespace PitchRentingSystem.Web.Controllers
{
    public class PitchesController : Controller
    {
        private readonly PitchRentingDbContext data;
        public PitchesController(PitchRentingDbContext data) 
                => this.data = data;


        public IActionResult All()
        {
            var allPitches = new AllPitchesViewModel()
            {
                Pitches = this.data.Pitches.Select(h => new PitchesDetailsViewModel
                {
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl
                })
            };
            return View(allPitches);
        }

        public IActionResult Details(int id)
        {
            var pitch = this.data.Pitches.Find(id);

            if (pitch is null)
            {
                return BadRequest();
            }

            var pitchModel = new PitchesDetailsViewModel()
            {
                Title = pitch.Title,
                Address = pitch.Address,
                ImageUrl = pitch.ImageUrl
            };
            
            return View(pitchModel);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var currentUserId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var allPitches = new AllPitchesViewModel()
            {
                Pitches = this.data.Pitches
                .Where(h => h.Agent.UserId == currentUserId)
                .Select(h => new PitchesDetailsViewModel()
                {
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl
                })
            };

            return View(allPitches);
        }
    }
}
