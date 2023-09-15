using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.EditJob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageJobs.EditJob
{
    public class GetJobEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<GetJobRequest.Response>
    {
        private readonly JobPortalContext _context;

        public GetJobEndpoint(JobPortalContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet(GetJobRequest.RouteTemplate)]
        public override async Task<ActionResult<GetJobRequest.Response>> HandleAsync(int jobsId, CancellationToken cancellationToken = default)
        {
                var jobs = await _context.Jobs
                .Include(x => x.JobDescriptions)
                .Include(x=>x.JobRequirements)
                .Where(j => j.Owner == HttpContext.User.Identity!.Name!)
                .SingleOrDefaultAsync(x => x.Id == jobsId, cancellationToken: cancellationToken);

            if (jobs is null)
            {
                return BadRequest("Job could not be found.");
            }
            if (!jobs.Owner.Equals(HttpContext.User.Identity!.Name, StringComparison.OrdinalIgnoreCase) && !HttpContext.User.IsInRole("Administrator,Employer"))
            {
                return Unauthorized();
            }
                var response = new GetJobRequest.Response(new GetJobRequest.Jobs(
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
                jobs.JobDescriptions.Select(ri => new GetJobRequest.JobDescription(ri.JobsId, ri.Stage, ri.Description)),
                jobs.JobRequirements.Select(ri => new GetJobRequest.JobRequirement(ri.JobsId, ri.Stage, ri.Requirement))
                ));

            return Ok(response);
        }
    }
}
