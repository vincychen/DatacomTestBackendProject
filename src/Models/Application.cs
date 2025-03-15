namespace DatacomTestProject.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Initial;
        public DateTime DateApplied { get; set; } = DateTime.Now;
    }
}