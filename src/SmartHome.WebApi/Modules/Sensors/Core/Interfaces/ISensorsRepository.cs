using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository
{
    Task<TemperatureSensorDto>CreateTemperatureSensorAsync(TemperatureSensor tempSensor);
}