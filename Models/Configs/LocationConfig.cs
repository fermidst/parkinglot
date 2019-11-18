using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.Configs
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("location")
                .HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .HasColumnName("location_id")
                .ValueGeneratedOnAdd();

            builder.HasMany(l => l.Tickets)
                .WithOne(t => t.Location);
        }
    }
}
