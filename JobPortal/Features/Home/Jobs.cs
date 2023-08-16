namespace JobPortal.Features.Home
{
    public class Jobs
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

        public IEnumerable <JobDescription> JobDescriptions { get; set; } = Array.Empty<JobDescription>();
        public IEnumerable <JobRequirement> JobRequirements { get; set; } = Array.Empty<JobRequirement>();
    }
    public class JobDescription
    {
        public int Id { get; set; }
        public int JobsId { get; set; }
        public int Stage { get; set; }
        public string Description { get; set; } = "";
    }

    public class JobRequirement
    {
        public int Id { get; set; }
        public int JobsId { get; set; }
        public int Stage { get; set; }
        public string Requirement { get; set; } = "";
    }

}
