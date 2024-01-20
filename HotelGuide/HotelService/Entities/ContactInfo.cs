namespace HotelService.Entities
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MailAddress { get; set; }
        public string? Location { get; set; }
    }
}
