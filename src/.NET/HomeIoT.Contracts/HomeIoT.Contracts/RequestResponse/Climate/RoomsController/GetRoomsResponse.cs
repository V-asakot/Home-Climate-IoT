namespace IoT.Contracts.RequestResponse.Climate.RoomsController
{
    public record GetRoomsResponse(IEnumerable<RoomDto> Rooms);
}
