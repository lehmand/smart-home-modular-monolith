using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Api.Controllers;

[ApiController]
[Route("api/controller")]
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
       var createdDto = await _temperatureSensorRepository.CreateAsync(entity, cancellationToken);

       return CreatedAtAction(
        nameof(CreateTemperatureSensor),
        new { id = createdDto.Id},
        createdDto
       );
    }
}