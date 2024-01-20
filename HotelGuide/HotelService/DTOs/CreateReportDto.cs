namespace HotelService.DTOs
{
    public class CreateReportDto
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
        public string Location { get; set; }
        public int NumHotels { get; set; }
        public int NumPhoneNumbers { get; set; }
        public DateTime DateRequested { get; set; } = DateTime.Now;
        public ReportStatus Status { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
