using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JobPortal.Shared.Features.ManageEmployer;

namespace JobPortal.Api.Persistence.Entities;

public class Employers
{
    public int Id { get; set; }
    public int EmployerId { get; set; }
    public string EmployerName { get; set; } = "";
    public string EmployerEmail { get; set; } = "";
    public string EmployerPhone { get; set; } = "";
    public string Location { get; set; } = "";
    public string? Image { get; set; } = "";
    public string Description { get; set; } = "";

    //public ICollection<Jobs> Jobs { get; set; } = default!;

    //public ICollection<JobDescription> JobDescriptions { get; set; } = default!;

    //public ICollection<JobRequirement> JobRequirements { get; set; } = default!;

}
public class EmployerConfig : IEntityTypeConfiguration<Employers>
{
    public void Configure(EntityTypeBuilder<Employers> builder)
    {
        builder.Property(x => x.EmployerName).IsRequired();
        builder.Property(x => x.EmployerEmail).IsRequired();
        builder.Property(x => x.EmployerPhone).IsRequired();
        builder.Property(x => x.EmployerName).IsRequired();
        builder.Property(x => x.Location).IsRequired();
        builder.Property(x => x.Description).IsRequired();
    }
}

