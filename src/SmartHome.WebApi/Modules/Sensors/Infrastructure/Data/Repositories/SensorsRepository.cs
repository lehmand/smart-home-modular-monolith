using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

public class SensorsRepository<TEntity, TDto> : ISensorsRepository<TEntity, TDto> where TEntity : SensorBase
{
    private readonly SensorDbContext _context;
    private readonly IMapper _mapper;

    public SensorsRepository(SensorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>()
            .SingleOrDefaultAsync(e => e.Id == Id, cancellationToken);
    }
}