using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

public class SensorRepository : ISensorsRepository
{
    private readonly SensorDbContext _context;

    public SensorRepository(SensorDbContext context)
    {
        _context = context;
    }

    public async Task<TemperatureSensorDto>CreateTemperatureSensorAsync(TemperatureSensor tempSensor)
    {
        _context.TemperatureSensors.Add(tempSensor);
        await _context.SaveChangesAsync();

        return new TemperatureSensorDto
        {
            
        };
    }
}