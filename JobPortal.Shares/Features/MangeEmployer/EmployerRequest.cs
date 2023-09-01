using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.MangeEmployer
{
    public record EmployerRequest(EmployerDto Employer) : IRequest<EmployerRequest.Response>
    {
        public const string RouteTemplate = "/api/Employers";

        public record Response(bool IsSuccess);
    }

    public class EployerRequestValidator : AbstractValidator<EmployerRequest>
    {
        public EployerRequestValidator()
        {
            RuleFor(x => x.Employer).SetValidator(new EmployerValidator());
        }
    }
}
