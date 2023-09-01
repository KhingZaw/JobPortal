using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Shared.Features.ManageJobs.EditJob;
using JobPortal.Shared.Features.MangeEmployer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageEmployer
{
    public class GetEmployerEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<GetEmployerRequest.Response>
    {
        private readonly JobPortalContext _context;

        public GetEmployerEndpoint(JobPortalContext context)
        {
            _context = context;
        }

        [HttpGet(GetEmployerRequest.RouteTemplate)]
        public override async Task<ActionResult<GetEmployerRequest.Response>> HandleAsync(int employerId, CancellationToken cancellationToken = default)
        {
            var employer = await _context.Employers.SingleOrDefaultAsync(x => x.Id == employerId, cancellationToken: cancellationToken);

            if (employer is null)
            {
                return BadRequest("Eployer could not be found.");
            }
            var response = new GetEmployerRequest.Response(new GetEmployerRequest.Employers(
                employer.Id,
                employer.EmployerName,
                employer.EmployerEmail,
                employer.EmployerPhone,
                employer.Location,
                employer.Description,
                employer.Image));

            return Ok(response);

        }
    }
}