using HomeIoT.Contracts.Enums;

namespace HomeIoTDevices.Service.Features.InitializeDevice
{
    public record InitializeDeviceResult(Guid DeviceGuid, string DeviceName, DeviceType DeviceType);
}
