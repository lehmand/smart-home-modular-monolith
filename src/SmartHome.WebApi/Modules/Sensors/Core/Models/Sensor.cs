namespace SmartHome.WebApi.Modules.Sensors.Core.Models;

public abstract class Sensor
{
  public Guid Id { get; set; }
  public required string Room { get; set; } = string.Empty;
  public required SensorType Type { get; set; }
}

public enum SensorType
{
  Temperature = 0,
  Presence = 1,
  Humidity = 2
}
