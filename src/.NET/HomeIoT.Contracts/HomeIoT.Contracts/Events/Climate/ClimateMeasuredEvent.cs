namespace Iot.Common.Events.Climate
{
    public record ClimateMeasuredEvent(Guid DeviceGuid, float Temperature, float Humidity, DateTime MeasurmentTime);
}
