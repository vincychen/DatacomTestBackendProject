namespace DatacomTestProject.Models
{
    public enum ApplicationStatus
    {
        Initial,
        Interview,
        Offer,
        Rejected,
    }

    public class UpdateApplicationStatusDto
    {
        public int status { get; set; }
    }
}