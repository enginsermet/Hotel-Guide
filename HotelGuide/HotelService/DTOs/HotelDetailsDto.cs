namespace HotelService.DTOs
{
    public class HotelDetailsDto
    {
        public string AuthorizedName { get; set; }
        public string AuthorizedSurname { get; set; }
        public string CompanyTitle { get; set; }
        public List<ContactInfoDto> ContactInformation { get; set; }
    }
}
