namespace ReportService.Entities
{
    public class Report
    {
        public Guid UUID { get; set; }
        public DateTime DateRequested { get; set; }
        public ReportStatus Status { get; set; }
        public string Location { get; set; }
        public int NumHotels { get; set; }
        public int NumPhoneNumbers { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
