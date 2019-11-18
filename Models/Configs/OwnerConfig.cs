using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingLot.Models.Configs
{
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("owner")
                .HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .HasColumnName("owner_id")
                .ValueGeneratedOnAdd();
            builder.Property(o => o.Name)
                .HasColumnName("owner name");
            builder.Property(o => o.Phone)
                .HasColumnName("phone");

            builder.HasMany(o => o.Cars)
                .WithOne(c => c.Owner);
        }
    }
}
