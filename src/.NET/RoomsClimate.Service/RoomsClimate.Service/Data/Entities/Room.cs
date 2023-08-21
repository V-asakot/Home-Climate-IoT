namespace RoomsClimate.Service.Data.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
