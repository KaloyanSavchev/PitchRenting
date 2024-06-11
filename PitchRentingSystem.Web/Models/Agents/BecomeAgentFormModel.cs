using System.ComponentModel.DataAnnotations;
using static PitchRentingSystem.Web.Data.Constants.EntityConstants.AgentNumber;

namespace PitchRentingSystem.Web.Models.Agents
{
    public class BecomeAgentFormModel
    {
        [Phone]
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; init; } = null!;
    }
}
