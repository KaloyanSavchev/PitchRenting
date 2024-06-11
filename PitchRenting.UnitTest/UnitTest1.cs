using PitchRentingSystem.Web.Data.Entities;
using PitchRentingSystem.Web.Data;
using PitchRentingSystem.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PitchRentingSystem.Web.Models.Home;
using Moq;
using Xunit;
namespace PitchRenting.UnitTest
{
    [TestFixture]
    public class Tests
    {
        /*[Fact]
        public void Index_ReturnsViewWithCorrectData()
        {
            // Arrange
            var mockDbContext = new Mock<PitchRentingDbContext>();
            mockDbContext.Setup(db => db.Pitches.Count()).Returns(5); // Example total pitches count
            mockDbContext.Setup(db => db.Pitches.Where(p => p.RenterId != null).Count()).Returns(3); // Example total rents count
            mockDbContext.Setup(db => db.Pitches.OrderByDescending(c => c.Id)).Returns(() =>
            {
                var pitches = new[]
                {
                    new Pitch { Id = 1, Title = "Pitch 1", ImageUrl = "url1" },
                    new Pitch { Id = 2, Title = "Pitch 2", ImageUrl = "url2" },
                    new Pitch { Id = 3, Title = "Pitch 3", ImageUrl = "url3" }
                };
                return pitches.AsQueryable();
            });

            var controller = new HomeController(mockDbContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Assert.Equals("Index", result.ViewName);
            var model = result.Model as IndexViewModel;
            Assert.NotNull(model);
            Assert.Equals(5, model.TotalPitches);
            Assert.Equals(3, model.TotalRents);
            Assert.Equals(3, model.Pitches.Count()); // Assuming you're taking 3 pitches
        }*/
    }
}