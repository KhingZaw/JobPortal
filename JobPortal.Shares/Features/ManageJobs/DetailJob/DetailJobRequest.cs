using MediatR;

namespace JobPortal.Shared.Features.ManageJobs.DetailJob;
public record DetailJobRequest(int JobsId) : IRequest<DetailJobRequest.Response>
{
    public const string RouteTemplate = "/api/detailjobs/{jobsId}";

    public record Response(Jobs Jobs);
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
        DateTime Time,
        int Salary,
        IEnumerable<JobDescription> JobDescriptions,
        IEnumerable<JobRequirement> JobRequirements);
    public record JobDescription(
        int Id,
        int Stage,
        string Description);
    public record JobRequirement(
        int Id,
        int Stage,
        string Requirement);
}
