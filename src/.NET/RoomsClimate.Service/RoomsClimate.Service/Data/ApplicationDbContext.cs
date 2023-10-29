using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Device>()
                .HasOne(e => e.ThermostatSettings)
                .WithOne(e => e.Device)
                .HasPrincipalKey<Device>(e => e.DeviceGuid);

            new ApplicationDbIntializer(modelBuilder).Seed();
        }

        public DbSet<ClimateMeasurment> Measurments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ThermostatSettings> ThermostatsSettings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
