using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PitchRentingSystem.Web.Configurations;
using PitchRentingSystem.Web.Data.Entities;

namespace PitchRentingSystem.Web.Data
{
    public class PitchRentingDbContext : IdentityDbContext<IdentityUser>
    {
        public PitchRentingDbContext(DbContextOptions<PitchRentingDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pitch> Pitches { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Agent> Agents { get; set; } = null!;

        //do i need this think ＼（〇_ｏ）／
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new PitchConfiguration());
            
            base.OnModelCreating(builder);
        }
    }
}
