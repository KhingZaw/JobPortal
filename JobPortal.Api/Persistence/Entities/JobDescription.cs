using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Api.Persistence.Entities
{
    public class JobDescription
    {
        [Key]
        public int desc_id { get; set; }
        public int JobsId { get; set; }
        public int Stage { get; set; }
        public string Description { get; set; } = default!;

        public Jobs Jobs { get; set; } = default!;
    }

    public class JobDescriptionConfig : IEntityTypeConfiguration<JobDescription>
    {
        public void Configure(EntityTypeBuilder<JobDescription> builder)
        {
            builder.Property(x => x.desc_id).IsRequired();
            builder.Property(x => x.JobsId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}