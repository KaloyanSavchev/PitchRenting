namespace PitchRentingSystem.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static PitchRentingSystem.Web.Data.Constants.EntityConstants.CategoryConstants;
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(NameMaxLength), Required]
        public string Name { get; set; } = null!;

        public ICollection<Pitch> Pitches { get; set; } = new HashSet<Pitch>();
    }
}
