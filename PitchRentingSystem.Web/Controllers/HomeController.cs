using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Models;
using PitchRentingSystem.Web.Models.Home;
using PitchRentingSystem.Web.Models.Pitches;
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
            var totalPitches = this.data.Pitches.Count();
            var totalRents = this.data.Pitches.Where(p => p.RenterId != null).Count();

            var pitches = this.data.Pitches.OrderByDescending(c => c.Id).Select(c => new PitchIndexViewModel
            {
                Id = c.Id,
                Title = c.Title,
                ImageUrl = c.ImageUrl,
            }).Take(3).ToList();

            return View(new IndexViewModel
            {
                TotalPitches = totalPitches,
                TotalRents = totalRents,
                Pitches = pitches
            });
        }
         
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error400");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }
    }
}
