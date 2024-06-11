using System.ComponentModel.DataAnnotations;
using static PitchRentingSystem.Web.Data.Constants.EntityConstants.PitchConstants;
namespace PitchRentingSystem.Web.Models.Pitches
{
    public class PitchFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; init; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; init; } = null!;


        [Required]
        [StringLength(DescriptionMaxLenth, MinimumLength = DescriptionMinLenth)]
        public string Description { get; init; } = null!;

        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; init; } = null!;

        [Required]
        [Range(0.00, 10000.00, ErrorMessage = "Price Per Rent must be a positive number and less than {2} leva.")]
        [Display(Name ="Price Per Rent")]
        public decimal PricePerRent { get; init; }

        [Display(Name ="Category")]
        public int CategoryId { get; init; }

        public IEnumerable<PitchCategoryViewModel> Categories { get; set; } = new List<PitchCategoryViewModel>();
    }
}
