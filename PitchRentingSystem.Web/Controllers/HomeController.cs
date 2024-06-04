using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Models;
using PitchRentingSystem.Web.Models.Home;
using System.Diagnostics;

namespace PitchRentingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PitchRentingDbContext data;
        
        public HomeController(PitchRentingDbContext data)
            => this.data = data;

        public IActionResult Index()
        {
            var allPitches = new IndexViewModel()
            {
                TotalPitches = this.data.Pitches.Count(),
                TotalRents = this.data.Pitches.Where(p => p.RenterId != null).Count(),
                Pitches = this.data.Pitches.Select(h => new PitchIndexViewModel()
                {
                    Title= h.Title,
                    ImageUrl = h.ImageUrl
                })               
            };
            return View(allPitches);
        }
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
