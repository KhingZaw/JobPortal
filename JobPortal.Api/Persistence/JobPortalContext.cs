using JobPortal.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Persistence;

public class JobPortalContext : DbContext
{
    public DbSet<Jobs> Jobs => Set<Jobs>();
    public DbSet<JobDescription> JobDescriptions => Set<JobDescription>();
    public DbSet<JobRequirement> JobRequirements => Set<JobRequirement>();
    public DbSet<Employers> Employers => Set<Employers>();
    public JobPortalContext(DbContextOptions<JobPortalContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new JobsConfig());
        modelBuilder.ApplyConfiguration(new JobDescriptionConfig());
        modelBuilder.ApplyConfiguration(new JobRequirementConfig());
        modelBuilder.ApplyConfiguration(new EmployerConfig());
    }
}