using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PitchRentingSystem.Web.Data.Entities
{
    using static PitchRentingSystem.Web.Data.Constants.EntityConstants.AgentConstants;
    public class Agent
    {
        public Agent() 
        {
            ManagedPitches = new HashSet<Pitch>();
            Id = Guid.NewGuid();
        }
        public Guid Id { get; init; } = Guid.NewGuid();

        [Phone]
        [MaxLength(PhoneNumberMaxLength), Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public ICollection<Pitch> ManagedPitches { get; set; }
    }
}
