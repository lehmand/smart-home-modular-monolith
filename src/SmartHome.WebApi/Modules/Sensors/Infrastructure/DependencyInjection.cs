using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContextPool<SensorDbContext>(opt =>
        opt.UseNpgsql(configuration.GetConnectionString("SensorContext")));
        services.AddScoped<ISensorsRepository, SensorRepository>();

        return services;
    }
}