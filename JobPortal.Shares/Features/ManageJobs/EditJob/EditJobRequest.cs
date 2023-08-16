using JobPortal.Shared.Features.ManageJobs.Shared;
using FluentValidation;
using MediatR;

namespace JobPortal.Shared.Features.ManageJobs.EditJob;
public record EditJobRequest(JobsDto Job) : IRequest<EditJobRequest.Response>
{
    public const string RouteTemplate = "/api/jobs";

    public record Response(bool IsSuccess);
}

public class EditJobRequestValidator : AbstractValidator<EditJobRequest>
{
    public EditJobRequestValidator()
    {
        RuleFor(x => x.Job).SetValidator(new JobsValidator());
    }
}