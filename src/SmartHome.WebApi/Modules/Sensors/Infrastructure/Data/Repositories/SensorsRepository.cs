using AutoMapper;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;

namespace SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

public class SensorsRepository<TEntity, TDto> : ISensorsRepository<TEntity, TDto> where TEntity : class
{
    private readonly SensorDbContext _context;
    private readonly IMapper _mapper;

    public SensorsRepository(SensorDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TDto> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TDto>(entity);
    }
}