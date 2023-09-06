﻿using JobPortal.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Api.Persistence.Entities;
public class Jobs
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? Image { get; set; }

    public string FrameworkName { get; set; } = "";

    public string PLanguage { get; set; } = "";

    public string EmployerName { get; set; } = "";

    public string JobType { get; set; } = "";

    public string CreatedDate { get; set; } = "";

    public string OpentoName { get; set; } = "";

    public string Opento { get; set; } = "";

    public int Salary { get; set; }

    public string SourceName { get; set; } = "";

    public string Description { get; set; } = "";

    public string Location { get; set; } = "";

    public string Owner { get; set; } = default!;

    public ICollection<JobDescription> JobDescriptions { get; set; } = default!;
    
    public ICollection<JobRequirement> JobRequirements { get; set; } = default!;

}

public class JobsConfig : IEntityTypeConfiguration<Jobs>
{
    public void Configure(EntityTypeBuilder<Jobs> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.FrameworkName).IsRequired();
        builder.Property(x => x.PLanguage).IsRequired();
        builder.Property(x => x.EmployerName).IsRequired();
        builder.Property(x => x.JobType).IsRequired();
        builder.Property(x => x.Salary).IsRequired();
        builder.Property(x => x.Location).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Owner).IsRequired();
     
    }
}