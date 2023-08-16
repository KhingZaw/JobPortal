using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Api.Persistence.Entities;
using JobPortal.Shared.Features.ManageJobs.AddJob;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortal.Api.Features.ManageJobs.AddJob;

public class AddJobEndpoint : BaseAsyncEndpoint.WithRequest<AddJobRequest>.WithResponse<int>
{
    private readonly JobPortalContext _database;

    public AddJobEndpoint(JobPortalContext database)
    {
        _database = database;
    }

    [HttpPost(AddJobRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddJobRequest request, CancellationToken cancellationToken = default)
    {
        var job = new Jobs
        {
            Name = request.Jobs.Name,
            Description = request.Jobs.Description,
            Location = request.Jobs.Location,
            //TimeInMinutes = 0,
            Salary = request.Jobs.Salary
        };

        await _database.Jobs.AddAsync(job, cancellationToken);

        var jobdescriptions = request.Jobs.JobDescriptions.Select(x => new JobDescription
        {
            Stage = x.Stage,
            Description = x.Description,
            Jobs = job
        });

        await _database.Jobs.AddAsync(job, cancellationToken);

        var jobrequirements = request.Jobs.JobRequirements.Select(x => new JobRequirement
        {
            Stage = x.Stage,
            Requirement = x.Requirement,
            Jobs = job
        });

        await _database.JobDescriptions.AddRangeAsync(jobdescriptions, cancellationToken);
        await _database.JobRequirements.AddRangeAsync(jobrequirements, cancellationToken);

        await _database.SaveChangesAsync(cancellationToken);

        return Ok(job.Id);
    }
}
