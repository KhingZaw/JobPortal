using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.Home.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JobPortal.Api.Features.Home.Shared
{
    public class GetJobsEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<GetJobsRequest.Response>
    {
        private readonly JobPortalContext _context;

        public GetJobsEndpoint(JobPortalContext context)
        {
            _context = context;
        }

        [HttpGet(GetJobsRequest.RouteTemplate)]
        public override async Task<ActionResult<GetJobsRequest.Response>> HandleAsync(int jobsId, CancellationToken cancellationToken = default)
        {
            var jobs = await _context.Jobs
                .Include(x => x.JobDescriptions)
                .Include(x => x.JobRequirements).ToListAsync(cancellationToken);

            var response = new GetJobsRequest.Response(jobs.Select(job => new GetJobsRequest.Jobs(
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
                job.Description,
                job.Location,
                job.CreatedDate,
                job.TimeInMinutes,
                job.Salary )));

            return Ok(response);
        }
    }
}
