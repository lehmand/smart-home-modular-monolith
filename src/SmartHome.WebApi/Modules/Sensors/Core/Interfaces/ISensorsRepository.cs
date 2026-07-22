namespace SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

public interface ISensorsRepository<TEntity, TDto> where TEntity : class
{
  Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
  Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
}
