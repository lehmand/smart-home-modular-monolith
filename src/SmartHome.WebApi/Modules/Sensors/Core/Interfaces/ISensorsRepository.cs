namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository<TEntity> where TEntity : class
{
  Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
}
