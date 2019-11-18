using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.Configs
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("car")
                .HasKey(c => c.RegistrationNumber);
            builder.Property(c => c.RegistrationNumber)
                .HasColumnName("registration_number");
            builder.Property(c => c.OwnerId)
                .HasColumnName("owner_id");
            builder.Property(c => c.VehicleBrand)
                .HasColumnName("vehicle_brand");
            builder.Property(c => c.Color)
                .HasColumnName("color");

            builder.HasOne(o => o.Owner)
                .WithMany(c => c.Cars)
                .HasForeignKey(o => o.OwnerId);
        }
    }
}
