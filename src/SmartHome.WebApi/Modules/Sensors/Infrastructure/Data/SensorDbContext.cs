using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure;

public class SensorDbContext(DbContextOptions<SensorDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SensorBase>()
            .HasDiscriminator(p => p.Type);
    }
}