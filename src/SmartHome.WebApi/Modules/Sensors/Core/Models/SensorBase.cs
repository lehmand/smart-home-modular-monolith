namespace SmartHome.WebApi.Modules.Sensors.Core.Models;

public abstract class SensorBase
{
  public Guid Id { get; set; }
  public string Room { get; set; } = string.Empty;
  public SensorType Type { get; set; }
}

public enum SensorType
{
  Temperature = 0,
  Presence = 1,
  Humidity = 2
}
