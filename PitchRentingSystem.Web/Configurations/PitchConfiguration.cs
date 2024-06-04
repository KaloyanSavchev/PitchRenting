namespace PitchRentingSystem.Web.Configurations
{
    using DataGenerator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PitchRentingSystem.Web.Data.Entities;
    public class PitchConfiguration : IEntityTypeConfiguration<Pitch>
    {
        public void Configure(EntityTypeBuilder<Pitch> builder)
        {
            builder.HasOne(h => h.Category)
                    .WithMany(c => c.Pitches)
                    .HasForeignKey(h => h.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Agent)
                .WithMany(a => a.ManagedPitches)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(DataGenerator.SeedHouse());
        }       
    }
}
