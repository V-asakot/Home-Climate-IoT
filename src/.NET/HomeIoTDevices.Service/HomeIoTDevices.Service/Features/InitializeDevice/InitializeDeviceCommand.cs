using HomeIoT.Contracts.Enums;
using MediatR;

namespace HomeIoTDevices.Service.Features.InitializeDevice
{
    public record InitializeDeviceCommand(Guid RoomGuid, Guid DeviceGuid, string DeviceName, DeviceType DeviceType) : IRequest<InitializeDeviceResult?>;
}
