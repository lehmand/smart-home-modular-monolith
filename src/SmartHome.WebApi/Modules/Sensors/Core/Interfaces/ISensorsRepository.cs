using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository<TEntity> : IRepository<TEntity> where TEntity : Sensor
{

}
