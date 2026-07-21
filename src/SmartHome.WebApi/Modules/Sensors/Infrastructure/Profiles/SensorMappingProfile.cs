using AutoMapper;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Profiles;

public class SensorMappingProfile : Profile
{
    public SensorMappingProfile()
    {
        CreateMap<TemperatureSensor, TemperatureSensorDto>().ReverseMap();
    }   
}