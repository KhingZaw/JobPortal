using FluentValidation;
using JobPortal.Shared.Features.ManageJobs.Shared;
using MediatR;

namespace JobPortal.Shared.Features.ManageJobs.AddJob;

public record AddJobRequest(JobsDto Jobs) : IRequest<AddJobRequest.Response>
{
    public const string RouteTemplate = "/api/jobs";

    public record Response(int JobsId);
}

public class AddJobsRequestValidator : AbstractValidator<AddJobRequest>
{
    public AddJobsRequestValidator()
    {
        RuleFor(x => x.Jobs).SetValidator(new JobsValidator());
    }
}
