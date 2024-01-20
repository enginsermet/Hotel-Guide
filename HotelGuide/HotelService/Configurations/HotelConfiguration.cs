using HotelService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(a => a.UUID);
            builder.HasMany(a => a.ContactInformation).WithOne().HasForeignKey(b => b.HotelId);
        }
    }
}
