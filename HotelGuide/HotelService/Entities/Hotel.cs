namespace HotelService.Entities
{
    public class Hotel
    {
        public Guid UUID { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedSurname { get; set; }
        public string CompanyTitle { get; set; }
        public ICollection<ContactInfo> ContactInformation { get; set; }
    }
}
