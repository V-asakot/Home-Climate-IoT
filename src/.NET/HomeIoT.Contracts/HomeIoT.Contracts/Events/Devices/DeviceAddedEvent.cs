using HomeIoT.Contracts.Enums;

namespace HomeIoT.Contracts.Events.Devices
{
    public record DeviceAddedEvent(string DeviceName, Guid DeviceGuid, Guid RoomGuid, DeviceType DeviceType);
}
