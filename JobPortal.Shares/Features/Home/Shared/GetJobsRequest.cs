using MediatR;

namespace JobPortal.Shared.Features.Home.Shared
{
    public record GetJobsRequest : IRequest<GetJobsRequest.Response>
    {
        public const string RouteTemplate = "/api/jobs";
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
            string Description,
            string Location,
            int Salary);
        public record Response(IEnumerable<Jobs> Jobs);
    }
}
