using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Api.Persistence.Entities;
using JobPortal.Shared.Features.ManageJobs.EditJob;
using JobPortal.Shared.Features.ManageEmployer;
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
            var employer = await _context.Employers.ToListAsync(cancellationToken);

            var response = new GetEmployerRequest.Response(employer.Select(employer => new GetEmployerRequest.Employers(
                employer.Id,
                employer.EmployerName,
                employer.EmployerEmail,
                employer.EmployerPhone,
                employer.Image,
                employer.Location,
                employer.Description
                )));

            return Ok(response);

        }
    }
}