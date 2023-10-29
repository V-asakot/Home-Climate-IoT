using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Data;

public class ApplicationDbIntializer
{
    private readonly ModelBuilder modelBuilder;

    public ApplicationDbIntializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<ThermostatSettings>().HasData(
               new ThermostatSettings()
                {
                    Id = 1,
                    ThermostatName = "Default",
                    ThermostatValue = 24,
                    IsActive = true
                }
        );
    }
}