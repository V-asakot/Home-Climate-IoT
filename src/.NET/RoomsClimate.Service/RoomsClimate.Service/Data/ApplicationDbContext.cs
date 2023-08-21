using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;
using System.Diagnostics.Metrics;

namespace RoomsClimate.Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClimateMeasurment> Measurments { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
