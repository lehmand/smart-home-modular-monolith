using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository
{
    Task<TDto>CreateSensorAsync<TDto,TModel>(TModel sensor)
        where TDto : SensorDto
        where TModel : SensorBase;
}