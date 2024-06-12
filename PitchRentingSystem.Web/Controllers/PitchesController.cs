using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Models.Pitches;
using System.Security.Claims;
using PitchRentingSystem.Web.Infrastructure;
using PitchRentingSystem.Web.Data.Entities;
using System.Drawing;
using PitchRentingSystem.Web.Models;

namespace PitchRentingSystem.Web.Controllers
{
    public class PitchesController : Controller
    {
        private readonly PitchRentingDbContext data;
        public PitchesController(PitchRentingDbContext data) 
                => this.data = data;


        public IActionResult All([FromQuery] AllPitchesQueryModel query)
        {
            var pitchesQuery = this.data.Pitches.AsQueryable();


            var allPitches = new AllPitchesQueryModel()
            {
                Pitches = this.data.Pitches.Select(h => new PitchesDetailsViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerRent = h.PricePerRent
                })
            };
            return View(allPitches);
            
            //return View(query);
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
                ImageUrl = pitch.ImageUrl,
                Description = pitch.Description,
                PricePerRent = pitch.PricePerRent,
                
            };
            
            return View(pitchModel);
        }

        [Authorize]
        public IActionResult Mine()
        {
            var allPitches = new AllPitchesQueryModel()
            {
                Pitches = this.data.Pitches
                    .Where(p => p.Agent.UserId == this.User.Id())
                    .Select(p => new PitchesDetailsViewModel()
                    {
                        Title = p.Title,
                        Address = p.Address,
                        ImageUrl = p.ImageUrl
                    }),
            };

            return View(allPitches);
        }

        public IActionResult Add(PitchFormModel model)
        {
            if (!this.data.Agents.Any(a => a.UserId == this.User.Id()))
            {
                return RedirectToAction(nameof(AgentsController.Become), "Agents");
            }

            if (!this.data.Categories.Any(c => c.Id == model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = this.GetPitchCategories();
                return View(model);
            }

            var agentId = this.data.Agents
                .First(a => a.UserId == this.User.Id()).Id;

            var pitch = new Pitch
            {
                Title = model.Title,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerRent = model.PricePerRent,
                CategoryId = model.CategoryId,
                AgentId = agentId
            };
            this.data.Pitches.Add(pitch);
            this.data.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = pitch.Id });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var pitch = this.data.Pitches.Find(id);

            if (pitch is null)
            {
                return BadRequest();
            }
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == pitch.AgentId);

            if (agent?.UserId != this.User.Id())
            {
                return Unauthorized();
            }
            var pitchModel = new PitchFormModel()
            {
                Title = pitch.Title,
                Address = pitch.Address,
                Description = pitch.Description,
                ImageUrl = pitch.ImageUrl,
                PricePerRent = pitch.PricePerRent,
                CategoryId = pitch.CategoryId,
                Categories = this.GetPitchCategories()
            };

            return View(pitchModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, PitchFormModel model)
        {
            var pitch = this.data.Pitches.Find(id);
            if (pitch is null)
            {
                return BadRequest();
            }
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == pitch.AgentId);

            if (agent?.UserId != this.User.Id())
            {
                return Unauthorized();
            }
            if (!this.data.Categories.Any(c => c.Id == model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }
            if (!ModelState.IsValid)
            {
                model.Categories = this.GetPitchCategories();

                return View(model);
            }

            pitch.Title = model.Title;
            pitch.Address = model.Address;
            pitch.Description = model.Description;
            pitch.ImageUrl = model.ImageUrl;
            pitch.PricePerRent = model.PricePerRent;
            pitch.CategoryId = model.CategoryId;
            this.data.SaveChanges();

            return RedirectToAction(nameof(Details), new {id = pitch.Id});
        } 

        private IEnumerable<PitchCategoryViewModel> GetPitchCategories()
            => this.data.Categories.Select(c => new PitchCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

        [Authorize]
        public IActionResult Delete(int id)
        {
            var pitch = this.data.Pitches.Find(id);
            if (pitch == null)
            {
                return BadRequest();    
            }
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == pitch.AgentId);
            if (agent?.UserId != this.User.Id())
            {
                return Unauthorized();
            }
            var model = new PitchViewModel()
            {
                Title = pitch.Title,
                Address = pitch.Address,
                ImageUrl = pitch.ImageUrl,
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(PitchViewModel model)
        {
            var pitch =this.data.Pitches.Find(model.Id);

            if (pitch is null)
            {
                return BadRequest();
            }
            var agent = this.data.Agents.FirstOrDefault(a => a.Id == pitch.AgentId);
            if (agent?.UserId != this.User.Id())
            {
                return Unauthorized();
            }
            this.data.Pitches.Remove(pitch);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rent(int id)
        {
            var pitch = this.data.Pitches.Find(id);
            if (pitch is null)
            {
                return BadRequest();
            }
            if (this.data.Agents.Any(a => a.UserId == this.User.Id()))
            {
                return Unauthorized();
            }
            if (pitch.RenterId is not null)
            {
                return BadRequest();
            }
            pitch.RenterId = this.User.Id();
            this.data.SaveChanges();

            return RedirectToAction(nameof(All), "Pitches");           
        }

        [Authorize]
        [HttpPost]
        public IActionResult Leave(int id)
        {
            var pitch = this.data.Pitches.Find(id);

            if (pitch is null || pitch.RenterId is not null)
            {
                return BadRequest();
            }

            if (this.data.Agents.Any(a => a.UserId == this.User.Id()))
            {
                return Unauthorized();
            }

            pitch.RenterId = null;
            this.data.SaveChanges();

            return RedirectToAction(nameof(All), "Pitches");
        }
    }
}

/*if (!string.IsNullOrWhiteSpace(query.Category))
            {
                pitchesQuery = this.data.Pitches.Where(p => p.Category.Name == query.Category);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                pitchesQuery = pitchesQuery.Where(p =>
                    p.Title.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Address.ToLower().Contains(query.SearchTerm.ToLower()) ||
                    p.Description.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            pitchesQuery = query.Sorting switch
            {
                PitchSorting.Price => pitchesQuery.OrderBy(p => p.PricePerRent),
                PitchSorting.NotRentedFirst => pitchesQuery.OrderBy(p => p.RenterId != null).ThenByDescending(p => p.Id),
                _ => pitchesQuery.OrderByDescending(p => p.Id),
            };*/

/*var pitches = pitchesQuery
    *//*.Skip((query.CurrentPage - 1) * AllPitchesQueryModel.PitchesPerPage)
    .Take(AllPitchesQueryModel)*//*
    .Select(p => new PitchViewModel
    {
        Id = p.Id,
        Title = p.Title,
        Address = p.Address,
        ImageUrl = p.ImageUrl,
        IsRented = p.RenterId != null,
        PricePerRent = p.PricePerRent
    }).ToList();

var pitchCategories = this.data
    .Categories
    .Select(c => c.Name)
    .Distinct()
    .OrderBy(c => c).ToList();*/
// query.Categories = pitchCategories;


// query.TotalPitchesCount = pitchesQuery.Count();
