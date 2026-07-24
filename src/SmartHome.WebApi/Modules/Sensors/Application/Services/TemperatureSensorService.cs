using AutoMapper;
using SmartHome.WebApi.Modules.Sensors.Application.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Application.Services;

public class TemperatureSensorService<TemperatureSensorDto, TemperatureSensorDetailsDto> : ITemperatureSensorService<TemperatureSensorDto, TemperatureSensorDetailsDto>
{
    private readonly ISensorRepository<TemperatureSensor> _repository;
    private readonly IMapper _mapper;

    public TemperatureSensorService(ISensorRepository<TemperatureSensor> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TemperatureSensorDetailsDto> AddAsync(TemperatureSensorDto tempSensorDto, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TemperatureSensor>(tempSensorDto);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return _mapper.Map<TemperatureSensorDetailsDto>(created);
    }

    public async Task<TemperatureSensorDetailsDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return entity is null ? default(TemperatureSensorDetailsDto) : _mapper.Map<TemperatureSensorDetailsDto>(entity);
    }

    public async Task<TemperatureSensorDetailsDto?> UpdateAsync(Guid id, TemperatureSensorDetailsDto dto, CancellationToken cancellationToken)
    {
       var entity = await _repository.GetByIdAsync(id, cancellationToken);
       if(entity ==  null)
        {
            return default(TemperatureSensorDetailsDto);
        }

       _mapper.Map(dto, entity);
       var updated = await _repository.UpdateAsync(entity, cancellationToken);
       return _mapper.Map<TemperatureSensorDetailsDto>(updated);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(id, cancellationToken);
    }
}
