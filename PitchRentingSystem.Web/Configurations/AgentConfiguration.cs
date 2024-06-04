namespace PitchRentingSystem.Web.Configurations
{
    using DataGenerator;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PitchRentingSystem.Web.Data.Entities;

    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(DataGenerator.SeedAgents());
        }
    }
}
