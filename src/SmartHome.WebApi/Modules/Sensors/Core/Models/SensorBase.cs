namespace SmartHome.WebApi.Modules.Sensors.Core.Models;

public abstract class SensorBase
{
    Guid Id { get; set; }
    string Room { get; set; } = string.Empty;
}