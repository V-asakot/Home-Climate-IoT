using HomeIoT.Contracts.Enums;

namespace HomeIoT.Contracts.Events.Devices
{
    public record DeviceInitializedEvent(string DeviceName, Guid DeviceGuid, Guid RoomGuid, DeviceType DeviceType);
}
