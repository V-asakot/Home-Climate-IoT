using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClimateMeasurment> Measurments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
