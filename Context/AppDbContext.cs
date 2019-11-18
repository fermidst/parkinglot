using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkingLot.Models;
using ParkingLot.Models.Configs;

namespace ParkingLot.Context
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=course;Username=postgres;Password=postgres");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
            modelBuilder.ApplyConfiguration(new RateConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
    }
}
