using System.ComponentModel.DataAnnotations;
using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.DTOs;

public class TemperatureSensorCreateDto
{
  [Required]
  public string Room { get; set; } = string.Empty;
  [Required]
  public required SensorType Type { get; set; }
  public decimal? Temperature { get; set; }
}

public class TemperatureSensorDetailsDto
{
  public Guid Id { get; set; }
  [Required]
  public string Room { get; set; } = string.Empty;
  [Required]
  public required SensorType Type { get; set; }
  public decimal? Temperature { get; set; }
}