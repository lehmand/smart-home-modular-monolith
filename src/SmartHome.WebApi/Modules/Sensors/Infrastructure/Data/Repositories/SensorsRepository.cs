using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

public class SensorsRepository<TEntity> : ISensorsRepository<TEntity> where TEntity : Sensor
{
  private readonly SensorDbContext _context;

  public SensorsRepository(SensorDbContext context)
  {
    _context = context;
  }
  public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
    return entity;
  }

  public async Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
  {
    return await _context.Set<TEntity>()
        .SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
  }

  public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    _context.Entry(entity).State = EntityState.Modified;
    await _context.SaveChangesAsync(cancellationToken);
    return entity;
  }
}
