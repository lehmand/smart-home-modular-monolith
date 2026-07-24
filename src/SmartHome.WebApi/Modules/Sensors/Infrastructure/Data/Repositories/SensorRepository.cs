using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

public class SensorRepository<TEntity> : ISensorRepository<TEntity> where TEntity : Sensor
{
  private readonly SensorDbContext _context;

  public SensorRepository(SensorDbContext context)
  {
    _context = context;
  }

  public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
  {
    await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
    await _context.SaveChangesAsync(cancellationToken);
    return entity;
  }

  public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
  {
    return await _context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
  }

  public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
  {
    _context.Entry(entity).State = EntityState.Modified;
    await _context.SaveChangesAsync(cancellationToken);
    return entity;
  }

  public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
  {
    var rows = await _context.Set<TEntity>()
      .Where(e => e.Id == id)
      .ExecuteDeleteAsync(cancellationToken);

    return rows > 0;
  }
}