using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuide.Shared.DTOs
{
    public class CreateReportDto
    {
        public Guid UUID { get; set; } = Guid.NewGuid();
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
