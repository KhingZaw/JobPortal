using FluentValidation;

namespace JobPortal.Shared.Features.ManageJobs.Shared
{
    public enum ImageAction
    {
        None,
        Add,
        Remove
    }

    public class JobsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Image { get; set; }

        public string FrameworkName { get; set; } = "";

        public string PLanguage { get; set; } = "";

        public string EmployerName { get; set; } = "";

        public string JobType { get; set; } = "";

        public string CreatedDate { get; set; } = "";

        public string CreatedTime { get; set; } = "";

        public string OpentoName { get; set; } = "";

        public string Opento { get; set; } = "";

        public int Salary { get; set; }

        public string SourceName { get; set; } = "";

        public string Location { get; set; } = "";

        public string Description { get; set; } = "";

        public ImageAction ImageAction { get; set; }

        public List<JobDescription> JobDescriptions { get; set; } = new List<JobDescription>();
        
        public class JobDescription
        {
            public int Id { get; set; }
            public int Stage { get; set; }
            public string Description { get; set; } = "";
        }

        public List<JobRequirement> JobRequirements { get; set; } = new List<JobRequirement>();

        public class JobRequirement
        {
            public int Id { get; set; }
            public int Stage { get; set; }
            public string Requirement { get; set; } = "";
        }

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
            RuleForEach(x => x.JobRequirements).SetValidator(new JobRequirementValidator());
        }
    }

    public class JobDescriptionValidator : AbstractValidator<JobsDto.JobDescription>
    {
        public JobDescriptionValidator()
        {
            RuleFor(x => x.Stage).NotEmpty().WithMessage("Please enter a stage");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
        }
    }
    public class JobRequirementValidator : AbstractValidator<JobsDto.JobRequirement>
    {
        public JobRequirementValidator()
        {
            RuleFor(x => x.Stage).NotEmpty().WithMessage("Please enter a stage");
            RuleFor(x => x.Requirement).NotEmpty().WithMessage("Please enter a requirement");
        }
    }

}
