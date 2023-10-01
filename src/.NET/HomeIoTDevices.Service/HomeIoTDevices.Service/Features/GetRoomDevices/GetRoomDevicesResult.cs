using IoT.Contracts.RequestResponse.Devices.DevicesController;

namespace HomeIoTDevices.Service.Features.GetRoomDevices
{
    public record GetRoomDevicesResult(IEnumerable<DeviceDto> Devices);
}
