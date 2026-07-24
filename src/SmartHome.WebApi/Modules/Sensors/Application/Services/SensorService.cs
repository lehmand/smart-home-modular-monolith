using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SmartHome.WebApi.Modules.Sensors.Application.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

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
        return _mapper.Map<TemperatureSensorDetailsDto>(entity);
    }
}