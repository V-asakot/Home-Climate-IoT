using HomeIoT.Contracts.Enums;
using MediatR;

namespace HomeIoTDevices.Service.Features.AddDevice
{
    public record AddDeviceCommand(Guid RoomGuid, string DeviceName, DeviceType DeviceType) : IRequest<AddDeviceResult?>;
}
