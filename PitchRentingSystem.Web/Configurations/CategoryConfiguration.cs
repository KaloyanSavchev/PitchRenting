
namespace PitchRentingSystem.Web.Configurations
{
    using DataGenerator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PitchRentingSystem.Web.Data.Entities;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(DataGenerator.SeedCategories());
        }
    }
}
