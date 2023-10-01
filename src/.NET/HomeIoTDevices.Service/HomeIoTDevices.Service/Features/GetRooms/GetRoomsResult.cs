using IoT.Contracts.RequestResponse.Devices.RoomsController;

namespace HomeIoTDevices.Service.Features.GetRooms
{
    public record GetRoomsResult(IEnumerable<RoomDto> Rooms);
}
