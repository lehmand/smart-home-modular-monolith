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
  private readonly ITemperatureSensorService _service;
  private readonly IMapper _mapper;

  public SensorsController(ITemperatureSensorService service, IMapper mapper)
  {
    _service = service;
    _mapper = mapper;
  }

  [HttpPost("temperature")]
  public async Task<ActionResult<TemperatureSensorDetailsDto>> CreateTemperatureSensor([FromBody] TemperatureSensorDto tempSensorDto, CancellationToken cancellationToken)
  {
    var entity = _mapper.Map<TemperatureSensor>(tempSensorDto);
  }

  [HttpGet("temperature/{id}")]
  public async Task<ActionResult<TemperatureSensorDetailsDto>> GetTemperatureSensorById(Guid id, CancellationToken cancellationToken)
  {
    var entity = await _temperatureSensorRepository.GetByIdAsync(id, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }
    return Ok(_mapper.Map<TemperatureSensorDetailsDto>(entity));
  }

  [HttpPut("temperature/{id}")]
  public async Task<ActionResult<TemperatureSensorDetailsDto>> UpdateTemperatureSensor(Guid id, TemperatureSensorDetailsDto updatedSensor, CancellationToken cancellationToken)
  {
    var entity = await _temperatureSensorRepository.GetByIdAsync(id, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    _mapper.Map(updatedSensor, entity);

    await _temperatureSensorRepository.UpdateAsync(entity, cancellationToken);
    return Ok(_mapper.Map<TemperatureSensorDetailsDto>(entity));
  }
}
