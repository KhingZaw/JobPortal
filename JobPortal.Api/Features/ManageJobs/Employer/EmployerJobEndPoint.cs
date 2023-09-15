using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.Home.Shared;
using JobPortal.Shared.Features.ManageJobs.Employer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageJobs.Employer
{
    public class EmployerJobEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<EmployerJobRequest.Response>
    {
        private readonly JobPortalContext _context;

        public EmployerJobEndpoint(JobPortalContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet(EmployerJobRequest.RouteTemplate)]
    
        public override async Task<ActionResult<EmployerJobRequest.Response>> HandleAsync(int jobsId, CancellationToken cancellationToken = default)
        {
            var jobs = await _context.Jobs
            .Include(x => x.JobDescriptions)
            .Include(x => x.JobRequirements)
            .Where(j => j.Owner == HttpContext.User.Identity!.Name!)
            .ToListAsync(cancellationToken);

            if (jobs is null)
            {
                return BadRequest("Job could not be found.");
            }
            var response = new EmployerJobRequest.Response(jobs.Select(job => new EmployerJobRequest.Jobs
            (
            job.Id,
            job.Name,
            job.Image,
            job.FrameworkName,
            job.PLanguage,
            job.EmployerName,
            job.JobType,
            job.OpentoName,
            job.Opento,
            job.SourceName,
            job.Location,
            job.Description,
            job.Time,
            job.Salary,
            job.Owner)));

            return Ok(response);
        }
    }
}
