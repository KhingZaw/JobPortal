using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Api.Persistence.Entities;
using JobPortal.Shared.Features.ManageJobs.EditJob;
using JobPortal.Shared.Features.ManageJobs.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageJobs.Editjob;

public class EditJobEndpoint : BaseAsyncEndpoint.WithRequest<EditJobRequest>.WithResponse<bool>
{
    private readonly JobPortalContext _database;

    public EditJobEndpoint(JobPortalContext database)
    {
        _database = database;
    }

    [HttpPut(EditJobRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditJobRequest request, CancellationToken cancellationToken = default)
    {
        var job = await _database.Jobs.Include(x => x.JobDescriptions).SingleOrDefaultAsync(x => x.Id == request.Job.Id, cancellationToken: cancellationToken);
        //var job = await _database.Jobs.Include(x => x.JobRequirements).SingleOrDefaultAsync(x => x.Id == request.Job.JobsId, cancellationToken: cancellationToken);

        if (job is null)
        {
            return BadRequest("Job could not be found.");
        }

        job.Name = request.Job.Name;
        job.Description = request.Job.Description;
        job.Location = request.Job.Location;
        //job.TimeInMinutes = request.Trail.TimeInMinutes;
        job.Salary = request.Job.Salary;
        job.JobDescriptions = request.Job.JobDescriptions.Select(ri => new JobDescription
        {
            Stage = ri.Stage,
            Description = ri.Description,
            Jobs = job
        }).ToList();

        if (request.Job.ImageAction == ImageAction.Remove)
        {
            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", job.Image!));
            job.Image = null;
        }

        await _database.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}
