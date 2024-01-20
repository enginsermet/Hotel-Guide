using AutoMapper;
using ReportService.DTOs;
using ReportService.Entities;

namespace ReportService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}
