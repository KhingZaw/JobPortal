using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Shared.Features.ManageJobs
{
    public class JobsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Image { get; set; } = "";

        public string FrameworkName { get; set; } = "";

        public string PLanguage { get; set; } = "";

        public string EmployerName { get; set; } = "";

        public string JobType { get; set; } = "";

        public string CreatedDate { get; set; } = "";

        public string CreatedTime { get; set; } = "";

        public string OpentoName { get; set; } = "";

        public string Opento { get; set; } = "";

        public int Salary { get; set; } = 0;

        public string SourceName { get; set; } = "";

        public string Location { get; set; } = "";

        public string Description { get; set; } = "";

        public IEnumerable<JobDescription> JobDescriptions { get; set; } = Array.Empty<JobDescription>();
        public IEnumerable<JobRequirement> JobRequirements { get; set; } = Array.Empty<JobRequirement>();

        public class JobDescription
        {
            public int desc_id { get; set; }
            public int Stage { get; set; }
            public string description { get; set; } = "";
        }
    }

    public class JobRequirement
    {
        public int require_id { get; set; }
        public string requirement { get; set; } = "";
    }

    public class JobsValidator : AbstractValidator<JobsDto>
    {
        public JobsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Please enter a location");
            RuleFor(x => x.Salary).GreaterThan(0).WithMessage("Please enter a length");
            RuleForEach(x => x.JobDescriptions).SetValidator(new JobDescriptionValidator());
        }
    }

    public class JobDescriptionValidator : AbstractValidator<JobsDto.JobDescription>
    {
        public JobDescriptionValidator()
        {
            RuleFor(x => x.Stage).NotEmpty().WithMessage("Please enter a stage");
            RuleFor(x => x.description).NotEmpty().WithMessage("Please enter a description");
        }
    }

}
