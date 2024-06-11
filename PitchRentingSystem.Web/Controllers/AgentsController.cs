using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Data.Entities;
using PitchRentingSystem.Web.Infrastructure;
using PitchRentingSystem.Web.Models.Agents;

namespace PitchRentingSystem.Web.Controllers
{
    public class AgentsController : Controller
    {
        private readonly PitchRentingDbContext data;
        public AgentsController(PitchRentingDbContext data)
            => this.data = data;

        [HttpGet]
        public IActionResult Become()
        {
            BecomeAgentFormModel model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            if (this.data.Agents.Any(a => a.UserId == this.User.Id()))
            {
                return BadRequest();
            }
            if (this.data.Agents.Any(a => a.PhoneNumber == model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists. Please Enter another one.");
            }
            if (this.data.Pitches.Any(h => h.RenterId == this.User.Id()))
            {
                ModelState.AddModelError("Error", "You should have no rents to become agent!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var agent = new Agent()
            {
                UserId = this.User.Id()!,
                PhoneNumber = model.PhoneNumber
            };
            this.data.Agents.Add(agent);
            this.data.SaveChanges();

            return RedirectToAction(nameof(PitchesController.All), "Pitches");
        }
    }
}
