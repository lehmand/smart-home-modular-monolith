using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository<TEntity> where TEntity : SensorBase
{
  Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
  Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
  Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
