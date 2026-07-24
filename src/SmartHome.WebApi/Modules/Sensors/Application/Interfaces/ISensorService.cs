using SmartHome.WebApi.Modules.Sensors.Core.DTOs;

namespace SmartHome.WebApi.Modules.Sensors.Application.Interfaces;

public interface ISensorService : IService<TemperatureSensorDto, TemperatureSensorDetailsDto>
{
    
}