using MediatR;

namespace JobPortal.Shared.Features.ManageJobs.Employer;

public record EmployerJobRequest : IRequest<EmployerJobRequest.Response>
{
    public const string RouteTemplate = "/api/employerjobs";

     public record Jobs(
        int Id,
        string Name,
        string? Image,
        string FrameworkName,
        string PLanguage,
        string EmployerName,
        string JobType,
        string OpentoName,
        string Opento,
        string SourceName,
        string Location,
        string Description,
        DateOnly Date,
        int Salary,
        string Owner);
    public record Response(IEnumerable<Jobs> Jobs);
}