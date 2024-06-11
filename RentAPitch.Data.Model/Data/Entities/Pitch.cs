using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PitchRentingSystem.Web.Data.Entities
{
    using static PitchRentingSystem.Web.Data.Constants.EntityConstants.PitchConstants;
    public class Pitch
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenth)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "decimal(12,3)")]
        public decimal PricePerRent { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Agent))]
        public Guid AgentId { get; set; }
        public Agent Agent { get; set; } = null!;

        [ForeignKey(nameof(Renter))]
        public string? RenterId { get; set; }
        public IdentityUser? Renter { get; set; }
    }
}
