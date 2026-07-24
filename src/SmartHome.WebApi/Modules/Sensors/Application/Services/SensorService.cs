using AutoMapper;
using SmartHome.WebApi.Modules.Sensors.Application.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Application.Services;

public class SensorService<TDto> : ISensorService<TDto>
{
    private readonly ISensorRepository<TemperatureSensor> _repository;
    private readonly IMapper _mapper;

    public SensorService(ISensorRepository<TemperatureSensor> repository, IMapper mapper)
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
        return entity is null ? null : _mapper.Map<TemperatureSensorDetailsDto>(entity);
    }

    public async Task<TemperatureSensorDetailsDto?> UpdateAsync(Guid id, TemperatureSensorDetailsDto dto, CancellationToken cancellationToken)
    {
       var entity = await _repository.GetByIdAsync(id, cancellationToken);
       if(entity ==  null)
        {
            return null;
        }

       _mapper.Map(dto, entity);
       var updated = await _repository.UpdateAsync(entity, cancellationToken);
       return _mapper.Map<TemperatureSensorDetailsDto>(updated);
    }
}