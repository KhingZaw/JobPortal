using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Api.Persistence.Entities;
using JobPortal.Shared.Features.ManageJobs.EditJob;
using JobPortal.Shared.Features.ManageJobs.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System.Runtime.Versioning;
using System.Xml.Linq;

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
        var job = await _database.Jobs.Include(x => x.JobDescriptions)
            .Include(x => x.JobRequirements)
            .SingleOrDefaultAsync(x => x.Id == request.Job.Id, cancellationToken: cancellationToken);

        if (job is null)
        {
            return BadRequest("Job could not be found.");
        }
        job.Name = request.Job.Name;
        job.FrameworkName = request.Job.FrameworkName;
        job.PLanguage = request.Job.PLanguage;
        job.EmployerName = request.Job.EmployerName;
        job.JobType = request.Job.JobType;
        job.Opento = request.Job.Opento;
        job.Description = request.Job.Description;
        job.Location = request.Job.Location;
        job.CreatedDate = request.Job.CreatedDate;
        job.TimeInMinutes = request.Job.TimeInMinutes;
        job.Salary = request.Job.Salary;
        job.JobDescriptions = request.Job.JobDescriptions.Select(ri => new JobDescription
        {
            Stage = ri.Stage,
            Description = ri.Description,
            Jobs = job
        }).ToList();
        job.JobRequirements = request.Job.JobRequirements.Select(ri => new JobRequirement
        {
            Stage = ri.Stage,
            Requirement = ri.Requirement,
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
