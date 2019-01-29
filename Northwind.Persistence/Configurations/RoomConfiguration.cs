using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.RoomId);

            builder.Property(e => e.RoomId).HasColumnName("RoomID");
            builder.Property(e => e.Name).HasMaxLength(30);
            //builder.Property(e => e.NumberOfSeats)
            //builder.Property(e => e.Area)
            //builder.Property(e => e.WifiAccess)
            //builder.Property(e => e.Calendar)
        }
    }
}
