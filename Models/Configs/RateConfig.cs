using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.Configs
{
    public class RateConfig : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("rate")
                .HasKey(r => r.Id);
            builder.Property(o => o.Id)
                .HasColumnName("rate_id")
                .ValueGeneratedOnAdd();
            builder.Property(r => r.Type)
                .HasColumnName("type");
            builder.Property(r => r.Cost)
                .HasColumnName("cost");

            builder.HasMany(r => r.Tickets)
                .WithOne(t => t.Rate);
        }
    }
}
