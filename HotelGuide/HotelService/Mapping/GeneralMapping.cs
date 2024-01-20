using AutoMapper;
using HotelService.DTOs;
using HotelService.Entities;

namespace HotelService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, HotelDetailsDto>().ReverseMap();

            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
            CreateMap<ContactInfo, CreateHotelDto>().ReverseMap();
        }
    }
}
