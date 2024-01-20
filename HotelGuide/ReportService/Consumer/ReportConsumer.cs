using HotelGuide.Shared.Messages;
using MassTransit;
using ReportService.Data;
using ReportService.Entities;
using ReportStatus = ReportService.Entities;

namespace ReportService.Consumers
{
    public class ReportConsumer : IConsumer<ReportCreated>
    {
        private readonly ILogger<ReportCreated> _logger;
        private readonly ReportDbContext _dbcontext;

        // Other classes like any kind of DTO object could be used instead of ScheduleCreated object
        public ReportConsumer(ILogger<ReportCreated> logger, ReportDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        public async Task Consume(ConsumeContext<ReportCreated> context)
        {
            // This message could be store in a database
            // Or perform any task that is required in the project
            var message = "Report for following location: " + context.Message.Location + context.Message.DateRequested;

            Report report = new Report
            {
                UUID = context.Message.UUID,
                DateRequested = context.Message.DateRequested,
                Location = context.Message.Location,
                NumHotels = context.Message.NumHotels,
                NumPhoneNumbers = context.Message.NumPhoneNumbers,
                Status = ReportStatus.ReportStatus.Completed
            };
            _logger.LogInformation(message);
            await Task.CompletedTask;

            _dbcontext.Reports.Add(report);
            await _dbcontext.SaveChangesAsync();
        }
    }
}


