using HomeIoT.Contracts.Enums;

namespace IoT.Contracts.RequestResponse.Devices.DevicesController
{
    public record DeviceDto(Guid DeviceGuid,string DeviceName, DeviceType DeviceType);
}
