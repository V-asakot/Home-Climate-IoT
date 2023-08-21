using RoomsClimate.Service.Data.Entities;

namespace RoomsClimate.Service.Controllers.RoomsController
{
    public class GetRoomsResponse
    {
        public GetRoomsResponse(IEnumerable<Room> rooms)
        {
            Rooms = rooms;
        }

        public IEnumerable<Room> Rooms { get; set; } = null!;
    }
}
