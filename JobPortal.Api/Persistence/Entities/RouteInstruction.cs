using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortal.Api.Persistence.Entities;

public class RouteInstruction
{
    public int Id { get; set; }
    public int JobsId { get; set; }
    public int Stage { get; set; }
    public string Description { get; set; } = default!;

    public Jobs Jobs { get; set; } = default!;
}

public class RouteInstructionConfig : IEntityTypeConfiguration<RouteInstruction>
{
    public void Configure(EntityTypeBuilder<RouteInstruction> builder)
    {
        builder.Property(x => x.JobsId).IsRequired();
        builder.Property(x => x.Description).IsRequired();
    }
}
