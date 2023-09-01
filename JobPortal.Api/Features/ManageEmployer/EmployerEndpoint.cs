using Ardalis.ApiEndpoints;
using JobPortal.Api.Persistence;
using JobPortal.Api.Persistence.Entities;
using JobPortal.Shared.Features.MangeEmployer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Api.Features.ManageEmployer;

public class EmployerEndpoint : BaseAsyncEndpoint.WithRequest<EmployerRequest>.WithResponse<bool>
{
    private readonly JobPortalContext _database;

    public EmployerEndpoint(JobPortalContext database)
    {
        _database = database;
    }

    [HttpPut(EmployerRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EmployerRequest request, CancellationToken cancellationToken = default)
    {
        var employer = await _database.Employers.SingleOrDefaultAsync(x => x.Id == request.Employer.Id, cancellationToken: cancellationToken);
        if (employer is null)
        {
            return BadRequest("Job could not be found.");
        }
        employer.EmployerName = request.Employer.EmployerName;
        employer.EmployerEmail = request.Employer.EmployerEmail;
        employer.EmployerPhone = request.Employer.EmployerPhone;
        employer.Description = request.Employer.Description;
        employer.Location = request.Employer.Location;

        return Ok(true);
    }
}