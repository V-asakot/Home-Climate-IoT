using RoomsClimate.Service.Data.Dto;

namespace RoomsClimate.Service.Controllers.RoomsController
{
    public class GetRoomsResponse
    {
        public GetRoomsResponse(IEnumerable<RoomDto> rooms)
        {
            Rooms = rooms;
        }

        public IEnumerable<RoomDto> Rooms { get; set; } = null!;
    }
}
