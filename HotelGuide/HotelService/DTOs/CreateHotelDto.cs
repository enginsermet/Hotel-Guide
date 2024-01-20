namespace HotelService.DTOs
{
    public class CreateHotelDto
    {
        public string AuthorizedName { get; set; }
        public string AuthorizedSurname { get; set; }
        public string CompanyTitle { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MailAddress { get; set; }
        public string? Location { get; set; }
    }
}
