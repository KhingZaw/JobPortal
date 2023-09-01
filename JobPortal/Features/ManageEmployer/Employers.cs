namespace JobPortal.Features.ManageEmployer
{
    public class Employers
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string EmployerName { get; set; } = "";
        public string EmployerEmail { get; set; } = "";
        public string EmployerPhone { get; set; } = "";
        public string Location { get; set; } = "";
        public string? Image { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
