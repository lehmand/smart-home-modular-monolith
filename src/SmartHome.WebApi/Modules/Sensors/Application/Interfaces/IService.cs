using SmartHome.WebApi.Modules.Sensors.Core.DTOs;

namespace SmartHome.WebApi.Modules.Sensors.Application.Interfaces;

public interface IService<TDto>
{
    Task<TDto> AddAsync(TDto dto, CancellationToken cancellationToken);
    Task<TDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TDto> UpdateAsync(Guid id, TDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

}