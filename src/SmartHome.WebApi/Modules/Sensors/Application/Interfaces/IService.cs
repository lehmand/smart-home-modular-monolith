namespace SmartHome.WebApi.Modules.Sensors.Application.Interfaces;

public interface IService<TCreateDto, TDetailDto>
{
    Task<TDetailDto> AddAsync (TCreateDto dto, CancellationToken cancellationToken);
    Task<TDetailDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<TDetailDto?> UpdateAsync(Guid id, TDetailDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);

}