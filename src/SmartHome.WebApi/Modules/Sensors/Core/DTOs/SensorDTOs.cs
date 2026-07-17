using SmartHome.WebApi.Modules.Sensors.Core.Models;

namespace SmartHome.WebApi.Modules.Sensors.Core.DTOs;

public class SensorDto
{
    public Guid Id { get; set; }
    public string Room { get; set; } = string.Empty;
    public SensorType Type { get; set; }
}