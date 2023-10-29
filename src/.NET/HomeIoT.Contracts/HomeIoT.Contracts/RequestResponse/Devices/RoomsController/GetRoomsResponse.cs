namespace IoT.Contracts.RequestResponse.Devices.RoomsController
{
    public record GetRoomsResponse(IEnumerable<RoomDto> Rooms);
}