namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository<TEntity, TDto> where TEntity : class
{
  Task<TDto> CreateAsync(TEntity entity, CancellationToken cancellationToken);
}
