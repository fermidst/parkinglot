using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.Configs
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("ticket")
                .HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("ticket_id")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.RegistrationNumber)
                .HasColumnName("registration_number");
            builder.Property(t => t.ArrivalDate)
                .HasColumnName("arrival_date");
            builder.Property(t => t.DepartureDate)
                .HasColumnName("departure_date");
            builder.Property(t => t.LocationId)
                .HasColumnName("car_location");
            builder.Property(t => t.RateId)
                .HasColumnName("rate");

            builder.HasOne(t => t.Car)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.RegistrationNumber);
            builder.HasOne(t => t.Location)
                .WithMany(l => l.Tickets)
                .HasForeignKey(t => t.LocationId);
            builder.HasOne(t => t.Rate)
                .WithMany(r => r.Tickets)
                .HasForeignKey(t => t.RateId);
        }
    }
}
