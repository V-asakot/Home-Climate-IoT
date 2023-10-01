namespace IoT.Contracts.RequestResponse.Devices.DevicesController
{
    public record GetDevicesResponse(IEnumerable<DeviceDto> Devices);
}