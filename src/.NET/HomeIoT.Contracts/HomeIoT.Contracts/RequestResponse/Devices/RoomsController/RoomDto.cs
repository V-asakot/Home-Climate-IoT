using HomeIoT.Contracts.Enums;

namespace IoT.Contracts.RequestResponse.Devices.RoomsController
{
    public record RoomDto(Guid RoomGuid, string RoomName);
}