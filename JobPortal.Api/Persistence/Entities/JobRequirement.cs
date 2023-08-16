using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Api.Persistence.Entities
{
    public class JobRequirement
    {
        public int Id { get; set; }
        public int JobsId { get; set; }
        public int Stage { get; set; }
        public string Requirement { get; set; } = default!;

        public Jobs Jobs { get; set; } = default!;
    }
    public class JobRequirementConfig : IEntityTypeConfiguration<JobRequirement>
    {
        public void Configure(EntityTypeBuilder<JobRequirement> builder)
        {
            builder.Property(x => x.JobsId).IsRequired();
            builder.Property(x => x.Requirement).IsRequired();
        }

    }
}