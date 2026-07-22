using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorsController : ControllerBase
{
  private readonly ISensorsRepository<TemperatureSensor, TemperatureSensorDto> _temperatureSensorRepository;
  private readonly IMapper _mapper;

  public SensorsController(ISensorsRepository<TemperatureSensor, TemperatureSensorDto> temperatureSensorRepository, IMapper mapper)
  {
    _temperatureSensorRepository = temperatureSensorRepository;
    _mapper = mapper;
  }

  [HttpPost("temperature")]
  public async Task<ActionResult<TemperatureSensorDto>> CreateTemperatureSensor([FromBody] TemperatureSensorDto tempSensorDto, CancellationToken cancellationToken)
  {
    var entity = _mapper.Map<TemperatureSensor>(tempSensorDto);
    var createdEntity = await _temperatureSensorRepository.CreateAsync(entity, cancellationToken);

    return CreatedAtAction(
     nameof(GetTemperatureSensorById),
     new { id = createdEntity.Id },
     _mapper.Map<TemperatureSensorDto>(createdEntity)
    );
  }

  [HttpGet("temperature/{Id}")]
  public async Task<ActionResult<TemperatureSensorDto>> GetTemperatureSensorById(Guid Id, CancellationToken cancellationToken)
  {
    var entity = await _temperatureSensorRepository.GetByIdAsync(Id, cancellationToken);
    if(entity ==  null)
    {
      return NotFound();
    }
    return Ok(_mapper.Map<TemperatureSensorDto>(entity));
  }
}
