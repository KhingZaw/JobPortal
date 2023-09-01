using FluentValidation;
using JobPortal.Shared.Features.ManageJobs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.MangeEmployer
{
    public class EmployerDto
    {
        public int Id { get; set; }
        public string EmployerName { get; set; } = "";
        public string EmployerEmail { get; set; } = "";
        public string EmployerPhone { get; set; } = "";
        public string Location { get; set; } = "";
        public string? Image { get; set; }
        public string Description { get; set; } = "";
    }

    public class EmployerValidator : AbstractValidator<EmployerDto>
    {
        public EmployerValidator()
        {
            RuleFor(x => x.EmployerName).NotEmpty().WithMessage("Place Enter a EmployerName");
            RuleFor(x => x.EmployerEmail).NotEmpty().WithMessage("Please enter a EmployerEmail");
            RuleFor(x => x.EmployerPhone).NotEmpty().WithMessage("Please enter a EmployerPhone");

        }
    }
}