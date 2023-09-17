namespace RoomsClimate.Service.Data.Dto
{
    public class RoomDto
    {
        public Guid RoomGuid { get; set; }
        public string RoomName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
