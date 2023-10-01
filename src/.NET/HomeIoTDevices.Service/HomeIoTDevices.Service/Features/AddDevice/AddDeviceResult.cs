using HomeIoT.Contracts.Enums;

namespace HomeIoTDevices.Service.Features.AddDevice
{
    public record AddDeviceResult(Guid DeviceGuid, string DeviceName, DeviceType DeviceType);

}
