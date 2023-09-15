using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.DetailJob;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageJobs.Detailob
{
    public class DetailJobEntpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<DetailJobRequest.Response>
    {
        private readonly JobPortalContext _context;

        public DetailJobEntpoint(JobPortalContext context)
        {
            _context = context;
        }

        [HttpGet(DetailJobRequest.RouteTemplate)]
        public override async Task<ActionResult<DetailJobRequest.Response>> HandleAsync(int jobsId, CancellationToken cancellationToken = default)
        {
            var jobs = await _context.Jobs
            .Include(x => x.JobDescriptions)
            .Include(x => x.JobRequirements)
            .SingleOrDefaultAsync(x => x.Id == jobsId, cancellationToken: cancellationToken);

            if (jobs is null)
            {
                return BadRequest("Job could not be found.");
            }
            var response = new DetailJobRequest.Response(new DetailJobRequest.Jobs(
            jobs.Id,
            jobs.Name,
            jobs.Image,
            jobs.FrameworkName,
            jobs.PLanguage,
            jobs.EmployerName,
            jobs.JobType,
            jobs.OpentoName,
            jobs.Opento,
            jobs.SourceName,
            jobs.Location,
            jobs.Description,
            jobs.Time,
            jobs.Date,
            jobs.Salary,
            jobs.JobDescriptions.Select(ri => new DetailJobRequest.JobDescription(ri.JobsId, ri.Stage, ri.Description)),
            jobs.JobRequirements.Select(ri => new DetailJobRequest.JobRequirement(ri.JobsId, ri.Stage, ri.Requirement))
            ));

            return Ok(response);
        }
    }
}

