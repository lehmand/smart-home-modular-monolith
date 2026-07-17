using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data;

public class SensorDbContext(DbContextOptions<SensorDbContext> options) : DbContext(options)
{
    public DbSet<SensorBase> Sensors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SensorBase>()
            .HasDiscriminator<SensorType>("Type")
            .HasValue<TemperatureSensor>(SensorType.Temperature);
    }
}