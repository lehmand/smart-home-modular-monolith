using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SmartHome.WebApi.Modules.Sensors.Core.DTOs;
using SmartHome.WebApi.Modules.Sensors.Core.Interfaces;
using SmartHome.WebApi.Modules.Sensors.Core.Models;
using SmartHome.WebApi.Modules.Sensors.Infrastructure.Data.Repositories;

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
       var createdDto = _temperatureSensorRepository.CreateAsync(entity, cancellationToken);

       return CreatedAtAction(
        nameof(CreateTemperatureSensor),
        new { id = createdDto.Id},
        createdDto
       );
    }
}