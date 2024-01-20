using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuide.Shared.Messages
{
    public interface ReportCreated
    {
        public Guid UUID { get; set; }
        public string Location { get; set; }
        public int NumHotels { get; set; }
        public int NumPhoneNumbers { get; set; }
        public DateTime DateRequested { get; set; }
        public ReportStatus Status { get; set; }
    }

    public enum ReportStatus
    {
        Preparing,
        Completed
    }
}
