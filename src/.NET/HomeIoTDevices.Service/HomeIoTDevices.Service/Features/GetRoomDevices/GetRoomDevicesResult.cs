using HomeIoTDevices.Service.Data.Dto;

namespace HomeIoTDevices.Service.Features.GetRoomDevices
{
    public record GetRoomDevicesResult(IEnumerable<DeviceDto> Devices);
}
