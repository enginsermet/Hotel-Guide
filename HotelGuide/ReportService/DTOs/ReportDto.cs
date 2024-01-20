namespace ReportService.DTOs
{
    public class ReportDto
    {
        public string Location { get; set; }
        public DateTime DateRequested { get; set; }
        public ReportStatus Status { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
