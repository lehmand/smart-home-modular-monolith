using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.DTOs;

public class TemperatureSensorCreateDto
{
  public required string Room { get; set; } = string.Empty;
  public required SensorType Type { get; set; }
  public decimal? Temperature { get; set; }
}

public class TemperatureSensorDetailsDto
{
  public Guid Id { get; set; }
  public required string Room { get; set; } 
  public required SensorType Type { get; set; }
  public decimal? Temperature { get; set; }
}