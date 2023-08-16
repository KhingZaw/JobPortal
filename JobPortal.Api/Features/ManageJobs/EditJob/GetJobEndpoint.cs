using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.EditJob;
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

        [HttpGet(GetJobRequest.RouteTemplate)]
        public override async Task<ActionResult<GetJobRequest.Response>> HandleAsync(int jobsId, CancellationToken cancellationToken = default)
        {
            var jobs = await _context.Jobs.Include(x => x.JobDescriptions).SingleOrDefaultAsync(x => x.Id == jobsId, cancellationToken: cancellationToken);

            //var jobs = await _context.Jobs.Include(x => x.JobRequirements).SingleOrDefaultAsync(x => x.Id == jobsId, cancellationToken: cancellationToken);

            if (jobs is null) 
            {
                return BadRequest("Job could not be found.");
            }

            var response = new GetJobRequest.Response( new GetJobRequest.Jobs(
                jobs.Id,
                jobs.Name,
                jobs.Image,
                jobs.FrameworkName,
                jobs.PLanguage,
                jobs.EmployerName,
                jobs.JobType,
                jobs.Location,
                jobs.OpentoName,
                jobs.Opento,
                jobs.SourceName,
                jobs.Description,
                jobs.Salary,
                jobs.JobDescriptions.Select(ri => new GetJobRequest.JobDescription(ri.JobsId, ri.Stage, ri.Description)),
                jobs.JobRequirements.Select(ri => new GetJobRequest.JobRequirement(ri.Id, ri.Stage, ri.Requirement))));
            //jobs.TimeInMinutes,


            return Ok(response);
        }
    }
}
