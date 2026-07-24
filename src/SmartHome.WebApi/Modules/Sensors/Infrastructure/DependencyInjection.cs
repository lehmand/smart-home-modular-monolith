using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Api.Controllers;
using SmartHome.WebApi.Modules.Sensors.Application.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Application.Services;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Profiles;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastucture(
      this IServiceCollection services,
      IConfiguration configuration
  )
  {
    services.AddDbContext<SensorDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("SensorContext")));

    services.AddScoped<
        ISensorRepository<TemperatureSensor>,
        SensorRepository<TemperatureSensor>
    >();

    services.AddScoped<
      ISensorService<TemperatureSensor>,
      SensorService<TemperatureSensor>
    >();

    services.AddAutoMapper(cfg =>
    {
    }, typeof(SensorMappingProfile));

    return services;
  }
}
